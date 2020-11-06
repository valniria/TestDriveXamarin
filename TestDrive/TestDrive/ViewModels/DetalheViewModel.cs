﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
    public class DetalheViewModel : INotifyPropertyChanged
    {
        public Veiculo Veiculo { get; set; }

        public string TextoFreioAbs
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", Veiculo.FreioAbs);
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", Veiculo.ArCondicionado);
            }
        }

        public string TextoMp3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", Veiculo.Mp3Player);
            }
        }

        public bool TemFreioAbs
        {
            get
            {
                return Veiculo.TemFreioAbs;
            }
            set
            {
                Veiculo.TemFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMp3Player
        {
            get
            {
                return Veiculo.TemMp3Player;
            }
            set
            {
                Veiculo.TemMp3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
        }
    }
}
