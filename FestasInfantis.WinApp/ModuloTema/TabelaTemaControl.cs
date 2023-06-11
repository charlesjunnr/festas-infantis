﻿using FestasInfantis.Dominio.ModuloCliente;
using FestasInfantis.Dominio.ModuloTema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FestasInfantis.WinApp.ModuloTema
{
    public partial class TabelaTemaControl : UserControl
    {
        public TabelaTemaControl()
        {
            InitializeComponent();

            CriarColunas();

            gridTema.ConfigurarGridSomenteLeitura();

            gridTema.ConfigurarGridZebrado();
        }

        public void AtualizarLista(List<Tema> temas)
        {
            gridTema.Rows.Clear();

            temas.ForEach(i =>
            {
                gridTema.Rows.Add(i.Id, i.nome, String.Join(",", i.itens), $"RS{i.total}");
            });
        }


        public int BuscarIdSelecionado()
        {
            try
            {
                return Convert.ToInt32(gridTema.SelectedRows[0].Cells[0].Value);
            }
            catch (ArgumentOutOfRangeException)
            {
                return -1;
            }
        }

        private void CriarColunas()
        {
            DataGridViewColumn[] columns =
            {
                new DataGridViewTextBoxColumn()
                { Name = "id", HeaderText = "Número"},

                new DataGridViewTextBoxColumn()
                { Name = "nome", HeaderText = "Tema"},

                new DataGridViewTextBoxColumn()
                {Name = "itens", HeaderText = "Itens" },

                new DataGridViewTextBoxColumn()
                {Name = "valorTotal", HeaderText = "Valor Total" },

            };

            gridTema.Columns.AddRange(columns);
        }
    }
}