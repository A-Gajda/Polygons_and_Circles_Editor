# Edytor wielokątów i okręgów

Prosty edytor wielokątów i okręgów, umożliwiający dodawanie i usuwanie kształtów i wierzchołków, przesuwanie ich, a także tworzenie relacji między nimi.



Grafika Komputerowa 1, projekt 1 - Aleksandra Gajda

Żeby wykonać akcję, należy najpierw kliknąć odpowiadający jej przycisk. Wyjątkiem są akcje przesuwania (wierzchołków i krawędzi oraz środków okręgów) i zmieniania promienia okręgu. Aby można było je wykonać, ostatnio wciśniętym przyciskiem musi być przycisk Stop (lub żaden przycisk). Przesunięcie całego wielokąta wymaga uprzedniego wciśnięcia przycisku. Akcje związane z przesuwaniem (oraz zmianą promienia) wymagają dwukrotnego kliknięcia (double click). Akcje związane z usuwaniem wymagają podwójnego kliknięcia lub dwóch wolniejszych kliknięć (pierwsze zaznacza usuwany obiekt). Wyjątkiem jest usunięcie relacji, wykonuje się je pojedynczym kliknięciem. W przypadku przedwczesnego przerwania akcji wyświetla się komunikat informujący o niewprowadzeniu zmian.

Relacje:
Relacje implementują interfejs IRelation. Każda relacja przechowuje obiekty do których się odnosi. Każda relacja zawiera metody pozwalające z zewnątrz sprawdzić, czy odnosi się do danego obiektu, sprawdzić czy relacja jest zachowana oraz wymusić zachowanie relacji. Przy każdej zmianie figury wywoływana jest, poprzez dotyczące jej relacje, metoda wymuszająca zachowanie relacji, która odpowiednio modyfikuje figurę.
