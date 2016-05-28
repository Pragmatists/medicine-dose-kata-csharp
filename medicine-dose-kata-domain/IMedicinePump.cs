namespace medicine_dose_kata_domain
{
    public interface IMedicinePump
    {
        void Dose(Medicine medicine);
        int TimeSinceLastDoseInMinutes(Medicine medicine);
    }
}