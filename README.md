# 📘 Практика по C#: Коллекции, LinkedList, Dictionary, Стэк и Очередь

Набор из 5 практических задач для студентов 2 курса. Цель — отработать работу с негенериками/дженериками, списками, словарями и структурами данных стэк/очередь.

## 🎯 Темы
- **Необобщённые коллекции vs Обобщённые коллекции**
- **Связный список: `LinkedList<T>`**
- **Словарь: `Dictionary<TKey, TValue>`**
- **Стэк и Очередь**

---

## 📝 Как работать
1. Открой решение `App.sln` и проект `App`.
2. В каждой задаче в папке `App/Topics/...` лежит файл `Task.cs` с одним `namespace`. Реализуйте все требуемые типы/методы самостоятельно.
3. Запустите тесты проекта `App.Tests` (через IDE или `dotnet test`). Изначально проект может не собираться — это нормально. Ваша цель — реализовать код так, чтобы тесты стали зелёными.

> Подсказка: В описаниях ниже указаны ожидаемые публичные API (имена типов/методов и сигнатуры), под которые уже написаны тесты.

---

## 📁 Структура проекта
```
/App
  /Topics
    /Collections
      /T1_Collections
        Task.cs              # пустой файл с namespace: App.Topics.Collections.T1_Collections
    /LinkedList
      /T2_LinkedList
        Task.cs              # namespace: App.Topics.LinkedList.T2_LinkedList
      /T2b_DoubleLinkedList
        Task.cs              # namespace: App.Topics.LinkedList.T2b_DoubleLinkedList
    /Dictionary
      /T3_Dictionary
        Task.cs              # namespace: App.Topics.Dictionary.T3_Dictionary
    /StackQueue
      /T4_StackQueue
        Task.cs              # namespace: App.Topics.StackQueue.T4_StackQueue
/App.Tests
  # Зеркальная структура с тестами на каждую задачу
/.github/workflows
  ci.yml                     # CI: сборка и запуск тестов на каждый push/PR
```

---

## 🧱 Тема 1: Необобщённые коллекции vs Обобщённые коллекции
Namespace: `App.Topics.Collections.T1_Collections`

Реализуйте класс и методы:
- `public static class CollectionsTasks`
  - `public static System.Collections.ArrayList FilterUniqueStringsNonGeneric(System.Collections.IEnumerable source)`
    - Берёт произвольную негенерик-коллекцию, выбирает только строки, `Trim()`, убирает пустые, удаляет дубликаты с учётом регистра НЕчувствительно (case-insensitive), порядок — по первому появлению. Возвращает `ArrayList` из «нормализованных» строк (после `Trim()`), сохраняет регистр первой валидной встречи.
  - `public static System.Collections.Generic.List<string> FilterUniqueStringsGeneric(System.Collections.Generic.IEnumerable<string> source)`
    - Аналогично, но вход — generics. Игнорирует пустые/whitespace строки, удаляет дубликаты case-insensitive, сохраняет порядок и регистр первого появления. Возвращает список нормализованных (trimmed) строк.

Краевые случаи: пустые коллекции, полностью «несоответствующие» типы (для негенерик метода), смешанные типы, дубликаты, строки из пробелов.

---

## 🔗 Тема 2: `LinkedList<T>`
Namespace: `App.Topics.LinkedList.T2_LinkedList`

Реализуйте класс и метод:
- `public static class LinkedListTasks`
  - `public static System.Collections.Generic.LinkedList<int> RemoveDuplicates(System.Collections.Generic.LinkedList<int> list)`
    - Удаляет дубликаты из неотсортированного `LinkedList<int>`, оставляя первую встречу каждого значения (порядок сохраняется). Сложность — O(n) по времени и O(n) по памяти (можно использовать `HashSet<int>`). На `null` аргумент — `ArgumentNullException`.

Краевые случаи: пустой список, один элемент, все одинаковые, все разные.

---

### Доп. задача: Двусвязный список
Namespace: `App.Topics.LinkedList.T2b_DoubleLinkedList`

Реализуйте класс:
- `public class DoubleLinkedList<T>`
  - Свойства: `int Count { get; }`, `bool IsEmpty { get; }`, `T Current { get; }`
    - `Current` недоступен в пустом списке → `InvalidOperationException`.
  - Навигация: `bool MoveNext()`, `bool MovePrev()`, `void MoveFirst()`, `void MoveLast()`
    - `MoveNext/MovePrev` возвращают `false`, если переход невозможен (на последнем/первом элементе).
  - Модификация: `void AddFirst(T value)`, `void AddLast(T value)`, `void AddBeforeCurrent(T value)`, `void AddAfterCurrent(T value)`
    - На `AddBeforeCurrent/AddAfterCurrent` при пустом списке → `InvalidOperationException`.
    - Текущая позиция при добавлениях не меняется (указатель остаётся на прежнем элементе).
  - Утилита для тестов: `T[] ToArray()` — возвращает элементы слева направо.

Краевые случаи: пустой список (доступ к `Current`, `AddBeforeCurrent/AfterCurrent`), единичный элемент, добавление до первого и после последнего, смешанные операции навигации/вставки.

---

## 🔑 Тема 3: `Dictionary<TKey, TValue>`
Namespace: `App.Topics.Dictionary.T3_Dictionary`

Реализуйте класс и метод:
- `public static class DictionaryTasks`
  - `public static System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string,int>> TopNWords(string text, int n)`
    - Подсчитывает частоты слов в тексте, нормализуя к `lowercase`. Делит текст на слова по непробельным не-буквенно-цифровым символам (оставляем только группы `char.IsLetterOrDigit`). Возвращает топ `n` слов, отсортированных по убыванию частоты, затем по слову по возрастанию. Если `n <= 0` или `text` пустой/`null`, вернуть пустой список.

Краевые случаи: `n <= 0`, пустой текст, много разделителей, совпадения по частотам (проверка сортировки по слову).

---

## 📦 Тема 4: Стэк и Очередь (Очередь через два стэка)
Namespace: `App.Topics.StackQueue.T4_StackQueue`

Реализуйте тип:
- `public class MyQueue<T>`
  - Методы/свойства: `void Enqueue(T item)`, `T Dequeue()`, `T Peek()`, `int Count { get; }`, `bool IsEmpty { get; }`
  - Очередь должна быть реализована через две структуры `Stack<T>` с амортизированной сложностью O(1) на операции. На `Dequeue/Peek` из пустой — `InvalidOperationException`.

Краевые случаи: пустая очередь, один элемент, смешанные операции `Enqueue/Dequeue/Peek`.

---

## 🧪 Запуск тестов
- Через IDE (Test Explorer) или командой: `dotnet test`
- Изначально сборка/тесты могут падать — это ожидаемо. Реализуйте API по описанию, после чего сборка пройдёт и тесты станут зелёными.

## ⚙️ CI
- GitHub Actions workflow (`.github/workflows/ci.yml`) автоматически собирает решение и запускает тесты на каждый push/PR.
