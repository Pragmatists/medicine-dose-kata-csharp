Wearables staj� si� coraz bardziej popularne. Powoli wkraczaj� te� do �wiata medycyny.

Twoim zadaniem b�dzie napisanie kontrolera do SmartWatcha, kt�ry na podstawie stanu pacjenta dobierze odpowiedni� porcj�
 leku.

Aby pozna� stan pacjenta, SmartWatch komunikuje si� po Bluetooth Low Energy z niewielkim urz�dzeniem monitoruj�cym 
ci�nienie krwi pacjenta (skurczowe).

Aby poda� lek, SmartWatch komunikuje si� ze specjaln� pomp�, podaj�c� lek do krwi pacjenta.

Tw�j kontroler powinien obs�u�y� nast�puj�ce przypadki:

1. Gdy ci�nienie spadnie poni�ej 90, podaj 1 dawk� leku podnosz�cego ci�nienie.
2. Gdy ci�nienie spadnie poni�ej 60, podaj 2 dawki leku podnosz�cego ci�nienie.
3. Gdy ci�nienie wzro�nie powy�ej 150, podaj lek obni�aj�cy ci�nienie. 
5. Gdy pompa nie zadzia�a (mo�e si� to zdarzy� przy intensywnym ruchu r�k�), pon�w pr�b�.
6. Nie podawaj leku, je�li od ostatniej dawki up�yn�o 30 minut lub mniej.
7. Gdy ci�nienie spadnie poni�ej 55, najpierw wy�lij alarm do lekarza, nast�pnie podaj
 3 dawki leku podnosz�cego ci�nienie