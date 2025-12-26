using System;
using System.Collections.Generic;
using System.Text;

public static class Floyds
{ 
    /* Реализация алгоритма Флойда для поиска кратчайших путей во взвешенном графе.
    * Входные данные:      а - матрица инцидентности взвешенного графа
    * Выходные данные:     симметричная матрица кратчайших расстояний между парами вершин
    */

    public static double[,] Floyd(double[,] a)
    {
        int n = 9;
        double[,] d = new double[n, n];
        d = (double[,])a.Clone();
        for (int i = 1; i <= n; i++)
            for (int j = 0; j <= n - 1; j++)
                for (int k = 0; k <= n - 1; k++)
                    if (d[j, k] > d[j, i - 1] + d[i - 1, k])
                        d[j, k] = d[j, i - 1] + d[i - 1, k];
        return d;
    }
}
