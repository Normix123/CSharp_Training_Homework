# Tasks 
## Task 1. 
The National Weather Service of the United States determines the effective air temperature (taking into account the influence of wind) using the following formula:

w=35.74+0.6215T+0.4275T-35.75v0.16.

T is the **temperature in degrees Fahrenheit**, and v is the wind speed in **miles per hour**.

Create a console application where the **user** enters the temperature in **degrees Celsius**, the wind speed in **meters per second**, and gets the value of the effective air temperature **in degrees Celsius**.

* The specified formula is not valid if T is greater than 50 in absolute value, or if v is greater than 120 or less than 3. If these conditions are violated, the application performs the calculation and outputs the result, but after that it should display a warning that the result may be incorrect.

## Task 2. 
At startup, the application asks the user for two integers a and b (assume that the user enters the integers without errors). The application then outputs all positive integers in the range from a (inclusive) to b (inclusive), which in their binary representation have exactly 4 units. Develop a console application that implements the specified functionality.

## Task 3. 
[**10-sign ISBN**](https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D0%B6%D0%B4%D1%83%D0%BD%D0%B0%D1%80%D0%BE%D0%B4%D0%BD%D1%8B%D0%B9_%D1%81%D1%82%D0%B0%D0%BD%D0%B4%D0%B0%D1%80%D1%82%D0%BD%D1%8B%D0%B9_%D0%BD%D0%BE%D0%BC%D0%B5%D1%80_%D0%BA%D0%BD%D0%B8%D0%B3%D0%B8) – this is a digital code that uniquely identifies the book. It has the following form: d1d2d3d4d5d6d7d8d9d10. Digit d10 – is control. It is evaluated according to the condition that the expression

10d1+9d2+8d3+. . .+ 1d10

(the sum of the products of the code elements by the weight of their positions) must be a multiple of 11.

Create a program that requests a string of 9-digit characters (these are the first nine digits of the ISBN), calculates the checksum, and outputs the resulting ISBN. Do not check the correctness of the user's input - consider that the user does not make mistakes.

The control "digit" can be equal to 10. In this case, the symbol X is used to indicate it.


