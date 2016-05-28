using System;
using medicine_dose_kata_domain;
using NSubstitute;
using NUnit.Framework;

namespace medicine_dose_kata_tests
{
    public class MedicineDosingTest
    {
        private IAlertService alertService = Substitute.For<IAlertService>();
        private DoseController doseController;
        private IHealthMonitor healthMonitor = Substitute.For<IHealthMonitor>();
        private IMedicinePump medicinePump = Substitute.For<IMedicinePump>();

        [SetUp]
        public void SetUp()
        {
            alertService = Substitute.For<IAlertService>();
            healthMonitor = Substitute.For<IHealthMonitor>();
            medicinePump = Substitute.For<IMedicinePump>();
            medicinePump.TimeSinceLastDoseInMinutes(Arg.Any<Medicine>()).Returns(int.MaxValue);
            doseController = new DoseController(healthMonitor, medicinePump, alertService);
        }

        [Test]
        public void OneDoseOnLowBloodPressure()
        {
            healthMonitor.SystolicBloodPressure.Returns(89);

            doseController.CheckHealthAndApplyMedicine();

            medicinePump.Received().Dose(Medicine.PressureRaisingMedicine);
        }

        [Test]
        public void NoDoseOnNormalBloodPressure()
        {
            healthMonitor.SystolicBloodPressure.Returns(90);

            doseController.CheckHealthAndApplyMedicine();

            medicinePump.DidNotReceive().Dose(Medicine.PressureRaisingMedicine);
        }

        [Test]
        public void TwoDosesOnVeryLowBloodPressure()
        {
            healthMonitor.SystolicBloodPressure.Returns(59);

            doseController.CheckHealthAndApplyMedicine();

            medicinePump.Received(2).Dose(Medicine.PressureRaisingMedicine);
        }

        [Test]
        public void LowerHighBloodPressure()
        {
            healthMonitor.SystolicBloodPressure.Returns(151);

            doseController.CheckHealthAndApplyMedicine();

            medicinePump.Received().Dose(Medicine.PressureLoweringMedicine);
        }

        [Test]
        public void RetryDose()
        {
            healthMonitor.SystolicBloodPressure.Returns(89);
            medicinePump.When(x => x.Dose(Arg.Any<Medicine>())).Do(
                Callback.FirstThrow(new DoseUnsuccessfulException())
                );

            doseController.CheckHealthAndApplyMedicine();

            medicinePump.Received(2).Dose(Medicine.PressureRaisingMedicine);
        }

        [Test]
        public void DoNotDoseTwoOften()
        {
            healthMonitor.SystolicBloodPressure.Returns(89);
            medicinePump.TimeSinceLastDoseInMinutes(Medicine.PressureRaisingMedicine).Returns(29);

            doseController.CheckHealthAndApplyMedicine();

            medicinePump.DidNotReceive().Dose(Arg.Any<Medicine>());
        }

        [Test]
        public void AlertTheDoctor()
        {
            healthMonitor.SystolicBloodPressure.Returns(54);

            doseController.CheckHealthAndApplyMedicine();

            Received.InOrder(() =>
            {
                alertService.NotifyDoctor();
                medicinePump.Dose(Medicine.PressureRaisingMedicine);
                medicinePump.Dose(Medicine.PressureRaisingMedicine);
                medicinePump.Dose(Medicine.PressureRaisingMedicine);
            });
        }
    }
}