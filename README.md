Wearables staj¹ siê coraz bardziej popularne. Powoli wkraczaj¹ te¿ do œwiata medycyny.

Twoim zadaniem bêdzie napisanie kontrolera do SmartWatcha, który na podstawie stanu pacjenta dobierze odpowiedni¹ porcjê
 leku.

Aby poznaæ stan pacjenta, SmartWatch komunikuje siê po Bluetooth Low Energy z niewielkim urz¹dzeniem monitoruj¹cym 
ciœnienie krwi pacjenta (skurczowe).

Aby podaæ lek, SmartWatch komunikuje siê ze specjaln¹ pomp¹, podaj¹c¹ lek do krwi pacjenta.

Twój kontroler powinien obs³u¿yæ nastêpuj¹ce przypadki:

1. Gdy ciœnienie spadnie poni¿ej 90, podaj 1 dawkê leku podnosz¹cego ciœnienie.
2. Gdy ciœnienie spadnie poni¿ej 60, podaj 2 dawki leku podnosz¹cego ciœnienie.
3. Gdy ciœnienie wzroœnie powy¿ej 150, podaj lek obni¿aj¹cy ciœnienie. 
5. Gdy pompa nie zadzia³a (mo¿e siê to zdarzyæ przy intensywnym ruchu rêk¹), ponów próbê.
6. Nie podawaj leku, jeœli od ostatniej dawki up³ynê³o 30 minut lub mniej.
7. Gdy ciœnienie spadnie poni¿ej 55, najpierw wyœlij alarm do lekarza, nastêpnie podaj
 3 dawki leku podnosz¹cego ciœnienie