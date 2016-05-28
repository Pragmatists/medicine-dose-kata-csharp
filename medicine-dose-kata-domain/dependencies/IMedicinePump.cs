namespace medicine_dose_kata_domain.dependencies
{
    public interface IMedicinePump
    {
        void Dose(Medicine medicine);
        int TimeSinceLastDoseInMinutes(Medicine medicine);
    }
}