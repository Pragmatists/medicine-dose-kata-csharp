namespace medicine_dose_kata_domain
{
    public class DoseController
    {
        private readonly IAlertService alertService;
        private readonly IHealthMonitor healthMonitor;
        private readonly IMedicinePump medicinePump;

        public DoseController(IHealthMonitor healthMonitor, IMedicinePump medicinePump, IAlertService alertService)
        {
            this.healthMonitor = healthMonitor;
            this.medicinePump = medicinePump;
            this.alertService = alertService;
        }

        public void CheckHealthAndApplyMedicine()
        {
            if (healthMonitor.SystolicBloodPressure < 55)
            {
                alertService.NotifyDoctor();
                DosePressureRaisingMedicine();
            }
            if (healthMonitor.SystolicBloodPressure < 90) 
            {
                DosePressureRaisingMedicine();
            }
            if (healthMonitor.SystolicBloodPressure < 60)
            {
                DosePressureRaisingMedicine();
            }
            if (healthMonitor.SystolicBloodPressure > 150)
            {
                medicinePump.Dose(Medicine.PressureLoweringMedicine);
            }
        }

        private void DosePressureRaisingMedicine()
        {
            try
            {
                if (medicinePump.TimeSinceLastDoseInMinutes(Medicine.PressureRaisingMedicine) >= 30)
                {
                    medicinePump.Dose(Medicine.PressureRaisingMedicine);
                }
            }
            catch (DoseUnsuccessfulException e)
            {
                medicinePump.Dose(Medicine.PressureRaisingMedicine);
            }
        }
    }
}