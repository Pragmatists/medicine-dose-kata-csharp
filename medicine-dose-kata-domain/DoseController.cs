using medicine_dose_kata_domain.dependencies;

namespace medicine_dose_kata_domain
{
    public class DoseController
    {
        public DoseController(IHealthMonitor healthMonitor, IMedicinePump medicinePump, IAlertService alertService)
        {
        }

        public void CheckHealthAndApplyMedicine()
        {

        }
    }
}