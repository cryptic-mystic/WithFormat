WithFormat
==========
An Easier ToString Library

## Background
I get pretty frustrated with how string formatting works in .NET, expecially having to go look up the magic string I have to use to get my numbers formatted a certain way when calling ToString. So I decided to start working on a fluent library to cover some of the ugliness.

## Usage
If you have an integer that you want to format as percentage with a precision of three decimal places, normally you would do this:
	5.ToString("P3"); //yields %500.000

WithFormat lets you do the same thing in a fluent manner:
	5.WithPercent().WithPrecision(3).Format(); //also yields %500.000
    
This is especially handy when dealing with culture formatting. For example, if we want to write a long using a Japanese currency format:
	5.ToString("C", CultureInfo.CreateSpecificCulture("ja-JP"));