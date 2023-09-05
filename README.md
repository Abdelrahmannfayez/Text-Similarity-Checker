# Plagiarism Checker

## Overview

The Plagiarism Checker is a simple C# program designed to compare the similarity between two text files. It treats the text in these files as vectors, applies a weighting scheme, computes the dot product, normalizes the score, and then outputs the similarity percentage.

## Features

- Compare text similarity between two text files.
- User-friendly graphical interface.
- Quick and easy to use.

## Prerequisites

Before running the Plagiarism Checker, ensure that you have the following:

- Windows operating system.
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) installed on your machine.
- Two text files (.txt) that you want to compare.

## How to Use

1. Launch the Plagiarism Checker application.
2. Click the "Insert First File" button and select the first text file you want to compare.
3. Click the "Insert Second File" button and select the second text file.
4. Click the "Compare" button to analyze the similarity.
5. The program will display the similarity percentage between the two files.
6. You can clear the text boxes and results by clicking the "Clear" button.

## How it Works

The program uses a vector-based approach to compare text files. Here's a simplified explanation of the process:

1. Read the content of both text files.

2. Tokenize the text into words, removing punctuation and empty words.

3. Calculate the frequency of each word in both files.

4. Compute the dot product of the two frequency vectors.

5. Normalize the score to a percentage based on the angle between the vectors.

