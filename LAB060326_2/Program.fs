// Кушев Александр БАС-2
// Лабораторная работа №2 (Задание №2)

open System

// Функция проверки, является ли строка бинарным значением
let checkIfBin str =
    str |> String.forall (
        fun c -> c = '0' || c = '1'
    )

// Функция преобразования бинарной строки в число
let binToInt (str: string) =
    str 
    |> Seq.toList
    |> List.fold (
        fun acc ch -> acc * 2 + (int ch - int '0')
    ) 0

// Функция получения десятеричной суммы двоичных чисел
let sumInList list =
    let sum = List.fold (
        fun acc x -> acc + binToInt x
                ) 0 list
    sum

// Функция рекурсивного создания списка (с конечным числом элементов)
let rec createList oldList count =
    if count > 0 then
        printf "Введите элемент списка: "
        let element = string(Console.ReadLine())
        let result = checkIfBin element
        if not result then
            printfn "Введенная строка не является бинарной!"
            createList oldList count
        else
            let number = binToInt element
            if number >= 1 && number <= 9 then
                let newList =  element::oldList
                createList newList (count - 1)
            else
                printfn "Число вне заданного диапазона!"
                createList oldList count
    else
        oldList

[<EntryPoint>]
let main args = 
    printf "Введите количество элементов списка: "
    let number = int(Console.ReadLine())

    let list = createList [] number
    let result = sumInList list
    printfn "Сумма двоичных чисел в списке равна: %i" result

    System.Console.ReadKey() |> ignore
    0
