﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Minsk.CodeAnalysis;

namespace Minsk
{
    internal static class Program
    {
        private static void Main()
        {
            var showTree = false;
            while (true)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    return;

                if (line == "#showTree")
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "Showing parse trees" : "Not showing parse trees.");
                    continue;
                }
                else if (line == "#cls")
                {
                    Console.Clear();
                    continue;
                }

                var syntaxTree = SyntaxTree.Parse(line);

                if (showTree)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    PrettyPrint(syntaxTree.Root);
                    Console.ResetColor();
                }


                if (!syntaxTree.Diagnostics.Any())
                {
                    var e = new Evaluator(syntaxTree.Root);
                    var result = e.Evaluate();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var diagnostic in syntaxTree.Diagnostics)
                    {
                        Console.WriteLine(diagnostic);
                    }

                    Console.ResetColor();
                }
            }
        }

        static void PrettyPrint(SyntaxNode syntaxNode, string indent = "", bool isLast = true)
        {
            var marker = isLast ? "\u2514\u2500\u2500" : "\u251c\u2500\u2500";
            Console.Write(indent);
            Console.Write(marker);
            Console.Write(syntaxNode.Kind);

            if (syntaxNode is SyntaxToken t && t.Value != null)
            {
                Console.Write("  ");
                Console.Write(t.Value);
            }

            Console.WriteLine();
            indent += isLast ? "    " : "\u2502   ";

            var last = syntaxNode.GetChildren().LastOrDefault();

            foreach (var child in syntaxNode.GetChildren())
            {
                PrettyPrint(child, indent, child == last);
            }
        }
    }
}