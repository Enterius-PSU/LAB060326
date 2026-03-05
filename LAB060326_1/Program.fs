// Кушев Александр БАС-2
// Лабораторная работа №2 (Задание №1)

open System

// Функция расчета произведения цифр в числе
let rec mulNumbers x =
    if x = 0 then
        1
    else
        (x%10) * mulNumbers (x/10)

// Функция рекурсивного создания списка (с конечным числом элементов)
let rec createList oldList count =
    if count > 0 then

        printf "Введите элемент списка: "
        let element = int(Console.ReadLine())

        let newList =  oldList @ [element]
        createList newList (count - 1)
    else
        oldList

// Вывод элементов списка
let printList list =
    printf "Список: %A" list
    printfn ""

// Функция проверки частного случая и преобразования числа
let transform x = 
    if x = 0 then 
        0 
    else 
        mulNumbers x

[<EntryPoint>]
let main args = 
    printf "Введите количество элементов списка: "
    let number = int(Console.ReadLine())

    let list = createList [] number
    let result = List.map(fun i -> transform i) list
    printfn "Список после заданного расчета: "
    printList result

    System.Console.ReadKey() |> ignore
    0
