# Console Calculator

Данный калькулятор работает на основе вычисления постфиксной записи.
Принимает входную строку, содержащую математическое выражение (целые и десятично-дробные числа, знаки +, -, *, / и скобки) и выводит в консоль результат его вычисления.

Calculator

	Класс Calc
	Для данного класса есть интерфейс ICalc, который имеет один метод Calculate, выполняющий вычисление заданного выражения с помощью класса PostfixCalc.

	Класс PostfixCalc
	Преобразует входное выражение в постфиксную запись, также вычисляет само постфиксное выражение.

	Класс ParserString
	Обрабатывает входное выражение в соответствии с шаблоном. Шаблон строится на основе списка допустимых операций калькулятора.

	Класс OperationsCalculator
	Содержит список операций и их приоритеты для калькулятора. А также функции для добавления новых операций и установления их приоритетов. В данном классе есть два вида операций: бинарные и унарные.

Console Calculator

	Запуск консольного калькулятора.

Пример консольного ввода:
Введите выражение: 1+2-3
Результат: 0
