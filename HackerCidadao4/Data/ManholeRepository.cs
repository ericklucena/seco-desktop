using HackerCidadao4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerCidadao4.Data
{
    public class ManholeRepository
    {
        private Dictionary<int, Manhole> _Manholes { get; set; }

        private static  ManholeRepository _instance;

        public static ManholeRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ManholeRepository();
                return _instance;
            }
        }


        private ManholeRepository()
        {
            _Manholes = new Dictionary<int, Manhole>();

            foreach (Manhole m in _CreateMocks())
            {
                _Manholes.Add(m.Id, m);
            }
        }


        public List<Manhole> GetManholes(bool volumeAlert = false, bool gasAlert = false)
        {
            Dictionary<int, Manhole> filtered = new Dictionary<int, Manhole>();

            if (!volumeAlert && !gasAlert)
                filtered = _Manholes;
            else
            {
                foreach (Manhole m in _Manholes.Values)
                {
                    if (volumeAlert && m.VolumeState != EImportanceState.Normal)
                        filtered.Add(m.Id, m);
                    else if (gasAlert && m.GasState != EImportanceState.Normal)
                        filtered.Add(m.Id, m);
                }
            }


            return filtered.Values.ToList();

        }

        public void InsertSensorsValues(List<Sensor> sensors)
        {
            int i = 0;
            int size = sensors.Count;
            Random random = new Random();
            foreach (Manhole m in _Manholes.Values)
            {
                double value;
                Double.TryParse(sensors.ElementAt(i++ % size).Valor, out value);
                m.CurrentHeight = value;
                m.GasState = (EImportanceState) random.Next(0,2);
            }
        }

        private List<Manhole> _CreateMocks()
        {
            List<Manhole> mocks = new List<Manhole>();

            mocks.Add(new Manhole()
            {
                Id = 501,
                Name = "Bueiro " + 501,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.103560,
                Longitude = -34.910724,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 502,
                Name = "Bueiro " + 502,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.103578,
                Longitude = -34.910910,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 503,
                Name = "Bueiro " + 503,
                Street = "João Ivo da Silva, Rua",
                Latitude = -8.065091,
                Longitude = -34.909180,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 504,
                Name = "Bueiro " + 504,
                Street = "Belém, Estrada de",
                Latitude = -8.032296,
                Longitude = -34.879488,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 505,
                Name = "Bueiro " + 505,
                Street = "São Nicolau, Rua",
                Latitude = -8.106765,
                Longitude = -34.925860,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 506,
                Name = "Bueiro " + 506,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.089689,
                Longitude = -34.933992,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 507,
                Name = "Bueiro " + 507,
                Street = "São Paulo, Av.",
                Latitude = -8.079773,
                Longitude = -34.940728,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 508,
                Name = "Bueiro " + 508,
                Street = "Francisco Alves, Rua",
                Latitude = -8.067278,
                Longitude = -34.893830,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 509,
                Name = "Bueiro " + 509,
                Street = "Sul, Av.",
                Latitude = -8.075179,
                Longitude = -34.889954,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 510,
                Name = "Bueiro " + 510,
                Street = "Imperial, Rua",
                Latitude = -8.074596,
                Longitude = -34.890171,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 511,
                Name = "Bueiro " + 511,
                Street = "Imperial, Rua",
                Latitude = -8.074426,
                Longitude = -34.889726,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 512,
                Name = "Bueiro " + 512,
                Street = "Rio Largo, Av.",
                Latitude = -8.112915,
                Longitude = -34.953042,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 513,
                Name = "Bueiro " + 513,
                Street = "Conselheiro Teodoro, Rua",
                Latitude = -8.049306,
                Longitude = -34.915263,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 514,
                Name = "Bueiro " + 514,
                Street = "Beberibe, Av.",
                Latitude = -8.004510,
                Longitude = -34.895100,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 515,
                Name = "Bueiro " + 515,
                Street = "Benfica, Rua",
                Latitude = -8.058326,
                Longitude = -34.904122,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 516,
                Name = "Bueiro " + 516,
                Street = "Derby, Praça do",
                Latitude = -8.056757,
                Longitude = -34.899417,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 517,
                Name = "Bueiro " + 517,
                Street = "Beberibe, Av.",
                Latitude = -8.007810,
                Longitude = -34.889900,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 518,
                Name = "Bueiro " + 518,
                Street = "Dois Rios, Av.",
                Latitude = -8.109113,
                Longitude = -34.935269,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 519,
                Name = "Bueiro " + 519,
                Street = "Prof. Eduardo Wanderley Filho, Rua",
                Latitude = -8.082546,
                Longitude = -34.907681,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 520,
                Name = "Bueiro " + 520,
                Street = "Acadêmico Hélio Ramos, Rua",
                Latitude = -8.049597,
                Longitude = -34.954629,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 521,
                Name = "Bueiro " + 521,
                Street = "Conselheiro Portela, Rua",
                Latitude = -8.043868,
                Longitude = -34.898305,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 522,
                Name = "Bueiro " + 522,
                Street = "Conselheiro Rosa e Silva, Av.",
                Latitude = -8.036899,
                Longitude = -34.901582,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 523,
                Name = "Bueiro " + 523,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.052469,
                Longitude = -34.880509,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 524,
                Name = "Bueiro " + 524,
                Street = "Remédios, Estrada dos",
                Latitude = -8.070979,
                Longitude = -34.908135,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 525,
                Name = "Bueiro " + 525,
                Street = "Cosme Viana, Rua",
                Latitude = -8.074565,
                Longitude = -34.908909,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 526,
                Name = "Bueiro " + 526,
                Street = "Álvares de Azevedo, Rua",
                Latitude = -8.049589,
                Longitude = -34.888642,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 527,
                Name = "Bueiro " + 527,
                Street = "Jean Emile Favre, Rua",
                Latitude = -8.111191,
                Longitude = -34.919728,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 528,
                Name = "Bueiro " + 528,
                Street = "Paz, Rua",
                Latitude = -8.080049,
                Longitude = -34.905238,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 529,
                Name = "Bueiro " + 529,
                Street = "Armindo Moura, Av.",
                Latitude = -8.149344,
                Longitude = -34.912376,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 530,
                Name = "Bueiro " + 530,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.127410,
                Longitude = -34.915300,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 531,
                Name = "Bueiro " + 531,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.127376,
                Longitude = -34.915543,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 532,
                Name = "Bueiro " + 532,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.090385,
                Longitude = -34.908351,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 533,
                Name = "Bueiro " + 533,
                Street = "Caxangá, Av.",
                Latitude = -8.039323,
                Longitude = -34.941192,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 534,
                Name = "Bueiro " + 534,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.110056,
                Longitude = -34.912126,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 535,
                Name = "Bueiro " + 535,
                Street = "Apipucos, Av.",
                Latitude = -8.020359,
                Longitude = -34.939602,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 536,
                Name = "Bueiro " + 536,
                Street = "Regeneração, Rua da",
                Latitude = -8.020558,
                Longitude = -34.888830,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 537,
                Name = "Bueiro " + 537,
                Street = "Arquiteto Luis Nunes, Rua",
                Latitude = -8.090983,
                Longitude = -34.910663,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 538,
                Name = "Bueiro " + 538,
                Street = "Antônio de Góis, Av.",
                Latitude = -8.087182,
                Longitude = -34.884907,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 539,
                Name = "Bueiro " + 539,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.093115,
                Longitude = -34.943245,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 540,
                Name = "Bueiro " + 540,
                Street = "Apipucos, Av.",
                Latitude = -8.021102,
                Longitude = -34.934164,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 541,
                Name = "Bueiro " + 541,
                Street = "Prof. Joaquim Xavier de Brito, Rua",
                Latitude = -8.051118,
                Longitude = -34.934989,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 542,
                Name = "Bueiro " + 542,
                Street = "Padre Carapuceiro, Rua",
                Latitude = -8.11681,
                Longitude = -34.49022,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 543,
                Name = "Bueiro " + 543,
                Street = "D. João VI, Av. ( Canal do Jordão )",
                Latitude = -8.114238,
                Longitude = -34.902683,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 544,
                Name = "Bueiro " + 544,
                Street = "Prof. J. Medeiros, Av.",
                Latitude = -8.115377,
                Longitude = -34.900496,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 545,
                Name = "Bueiro " + 545,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.117400,
                Longitude = -34.896473,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 546,
                Name = "Bueiro " + 546,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.117851,
                Longitude = -34.895593,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 547,
                Name = "Bueiro " + 547,
                Street = "Boa Viagem, Av.",
                Latitude = -8.118568,
                Longitude = -34.894059,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 548,
                Name = "Bueiro " + 548,
                Street = "Boa Viagem, Av.",
                Latitude = -8.115285,
                Longitude = -34.892210,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 549,
                Name = "Bueiro " + 549,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.112921,
                Longitude = -34.892678,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 550,
                Name = "Bueiro " + 550,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.112446,
                Longitude = -34.893509,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 551,
                Name = "Bueiro " + 551,
                Street = "Félix de Brito, Rua",
                Latitude = -8.116791,
                Longitude = -34.897679,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 552,
                Name = "Bueiro " + 552,
                Street = "Derby, Praça do",
                Latitude = -8.056667,
                Longitude = -34.899444,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 553,
                Name = "Bueiro " + 553,
                Street = "Augusto Calheiros, Rua",
                Latitude = -8.081860,
                Longitude = -34.908968,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 554,
                Name = "Bueiro " + 554,
                Street = "Petronila V. Botelho, Rua",
                Latitude = -8.027809,
                Longitude = -34.889798,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 555,
                Name = "Bueiro " + 555,
                Street = "Boa Viagem, Av.",
                Latitude = -8.116989,
                Longitude = -34.893167,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 556,
                Name = "Bueiro " + 556,
                Street = "Cosme Viana, Rua",
                Latitude = -8.142032,
                Longitude = -34.911491,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 557,
                Name = "Bueiro " + 557,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.092282,
                Longitude = -34.937677,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 558,
                Name = "Bueiro " + 558,
                Street = "Gomes Taborda, Rua",
                Latitude = -8.05641,
                Longitude = -34.49206,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 559,
                Name = "Bueiro " + 559,
                Street = "Beberibe, Av.",
                Latitude = -8.006012,
                Longitude = -34.892094,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 560,
                Name = "Bueiro " + 560,
                Street = "Arquiteto Luis Nunes, Rua",
                Latitude = -8.090085,
                Longitude = -34.910495,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 561,
                Name = "Bueiro " + 561,
                Street = "Dois Rios, Av.",
                Latitude = -8.110539,
                Longitude = -34.936994,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 562,
                Name = "Bueiro " + 562,
                Street = "Rui Barbosa, Av.",
                Latitude = -8.047071,
                Longitude = -34.900733,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 563,
                Name = "Bueiro " + 563,
                Street = "Luis Correia de Brito, Av.",
                Latitude = -8.020518,
                Longitude = -34.873489,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 564,
                Name = "Bueiro " + 564,
                Street = "Jean Emile Favre, Rua",
                Latitude = -8.108570,
                Longitude = -34.916722,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 565,
                Name = "Bueiro " + 565,
                Street = "Jerônimo Vilela, Rua",
                Latitude = -8.029414,
                Longitude = -34.881878,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 566,
                Name = "Bueiro " + 566,
                Street = "Miguel Vieira Ferreira, Rua Dr.",
                Latitude = -8.051208,
                Longitude = -34.933048,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 567,
                Name = "Bueiro " + 567,
                Street = "Des. José Neves, Rua",
                Latitude = -8.126658,
                Longitude = -34.909940,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 570,
                Name = "Bueiro " + 570,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.13331,
                Longitude = -34.49164,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 571,
                Name = "Bueiro " + 571,
                Street = "Cais de Santa Rita",
                Latitude = -8.069236,
                Longitude = -34.876124,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 572,
                Name = "Bueiro " + 572,
                Street = "10 de Julho, Rua",
                Latitude = -8.134801,
                Longitude = -34.913548,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 573,
                Name = "Bueiro " + 573,
                Street = "10 de Julho, Rua",
                Latitude = -8.135172,
                Longitude = -34.911862,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 574,
                Name = "Bueiro " + 574,
                Street = "João Cardoso Aires, Rua",
                Latitude = -8.142274,
                Longitude = -34.908591,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 575,
                Name = "Bueiro " + 575,
                Street = "Beberibe, Av.",
                Latitude = -8.006926,
                Longitude = -34.890943,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 576,
                Name = "Bueiro " + 576,
                Street = "José Bonifácio, Rua",
                Latitude = -8.049136,
                Longitude = -34.906479,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 577,
                Name = "Bueiro " + 577,
                Street = "Gal. Polidoro, Rua",
                Latitude = -8.042460,
                Longitude = -34.946922,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 578,
                Name = "Bueiro " + 578,
                Street = "Soledade, Rua da",
                Latitude = -8.058852,
                Longitude = -34.889911,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 579,
                Name = "Bueiro " + 579,
                Street = "Aurora, Rua da",
                Latitude = -8.060809,
                Longitude = -34.880832,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 586,
                Name = "Bueiro " + 586,
                Street = "Delmiro Gouveia, Rua",
                Latitude = -8.063632,
                Longitude = -34.930486,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 593,
                Name = "Bueiro " + 593,
                Street = "Encanamento, Estrada do",
                Latitude = -8.030341,
                Longitude = -34.919003,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 594,
                Name = "Bueiro " + 594,
                Street = "Dois Rios, Av.",
                Latitude = -8.109820,
                Longitude = -34.936173,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 595,
                Name = "Bueiro " + 595,
                Street = "Joaquim Nabuco, Rua",
                Latitude = -8.052665,
                Longitude = -34.901092,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 596,
                Name = "Bueiro " + 596,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.01846,
                Longitude = -34.49285,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 597,
                Name = "Bueiro " + 597,
                Street = "Odete Monteiro, Rua",
                Latitude = -8.045478,
                Longitude = -34.921760,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 598,
                Name = "Bueiro " + 598,
                Street = "Harmonia, Rua da",
                Latitude = -8.026241,
                Longitude = -34.913430,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 599,
                Name = "Bueiro " + 599,
                Street = "Recife, Av.",
                Latitude = -8.097522,
                Longitude = -34.928591,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 600,
                Name = "Bueiro " + 600,
                Street = "Monsenhor Ambrosino Leite, Rua",
                Latitude = -8.050878,
                Longitude = -34.901050,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 601,
                Name = "Bueiro " + 601,
                Street = "José Bonifácio, Rua",
                Latitude = -8.044731,
                Longitude = -34.907491,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 602,
                Name = "Bueiro " + 602,
                Street = "Padre Lemos, Rua",
                Latitude = -8.024301,
                Longitude = -34.917945,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 603,
                Name = "Bueiro " + 603,
                Street = "Guararapes, Av.",
                Latitude = 8.636434,
                Longitude = -34.878893,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 604,
                Name = "Bueiro " + 604,
                Street = "Guararapes, Av.",
                Latitude = 8.635690,
                Longitude = -34.878803,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 605,
                Name = "Bueiro " + 605,
                Street = "Caxangá, Av.",
                Latitude = -8.036393,
                Longitude = -34.946281,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 606,
                Name = "Bueiro " + 606,
                Street = "Caxangá, Av.",
                Latitude = -8.046407,
                Longitude = -34.928610,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 607,
                Name = "Bueiro " + 607,
                Street = "Caxangá, Av.",
                Latitude = -8.043293,
                Longitude = -34.933760,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 608,
                Name = "Bueiro " + 608,
                Street = "Caxangá, Av.",
                Latitude = -8.036567,
                Longitude = -34.946324,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 609,
                Name = "Bueiro " + 609,
                Street = "Caxangá, Av.",
                Latitude = -8.034399,
                Longitude = -34.949951,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 610,
                Name = "Bueiro " + 610,
                Street = "Caxangá, Av.",
                Latitude = -8.043459,
                Longitude = -34.933822,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 611,
                Name = "Bueiro " + 611,
                Street = "21 de Abril, Rua",
                Latitude = -8.076367,
                Longitude = -34.913519,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 612,
                Name = "Bueiro " + 612,
                Street = "Estrada de Belém",
                Latitude = -8.032265,
                Longitude = -34.879187,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 613,
                Name = "Bueiro " + 613,
                Street = "Des. Goes Cavalcante, Rua",
                Latitude = -8.031017,
                Longitude = -34.908528,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 614,
                Name = "Bueiro " + 614,
                Street = "17 de Agosto, Av.",
                Latitude = -8.035525,
                Longitude = -34.912678,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 615,
                Name = "Bueiro " + 615,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.092823,
                Longitude = -34.946131,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 616,
                Name = "Bueiro " + 616,
                Street = "Recife, Av.",
                Latitude = -8.112691,
                Longitude = -34.926312,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 617,
                Name = "Bueiro " + 617,
                Street = "Recife, Av.",
                Latitude = -8.100470,
                Longitude = -34.928072,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 618,
                Name = "Bueiro " + 618,
                Street = "Recife, Av.",
                Latitude = -8.097504,
                Longitude = -34.928465,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 619,
                Name = "Bueiro " + 619,
                Street = "Recife, Av.",
                Latitude = -8.092766,
                Longitude = -34.929158,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 620,
                Name = "Bueiro " + 620,
                Street = "Recife, Av.",
                Latitude = -8.090861,
                Longitude = -34.929408,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 621,
                Name = "Bueiro " + 621,
                Street = "Recife, Av.",
                Latitude = -8.089031,
                Longitude = -34.929653,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 622,
                Name = "Bueiro " + 622,
                Street = "Regeneração, Rua da",
                Latitude = -8.018819,
                Longitude = -34.892932,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 623,
                Name = "Bueiro " + 623,
                Street = "Carlos Gomes, Rua",
                Latitude = -8.057961,
                Longitude = -34.910720,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 624,
                Name = "Bueiro " + 624,
                Street = "Visconde de Suassuna, Av.",
                Latitude = -8.052592,
                Longitude = -34.886268,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 625,
                Name = "Bueiro " + 625,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.139774,
                Longitude = -34.917560,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 626,
                Name = "Bueiro " + 626,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.139507,
                Longitude = -34.917362,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 627,
                Name = "Bueiro " + 627,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.048978,
                Longitude = -34.878004,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 628,
                Name = "Bueiro " + 628,
                Street = "Benfica, Rua",
                Latitude = -8.058146,
                Longitude = -34.906144,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 629,
                Name = "Bueiro " + 629,
                Street = "Benfica, Rua",
                Latitude = -8.057949,
                Longitude = -34.904100,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 630,
                Name = "Bueiro " + 630,
                Street = "Conde de Irajá, Rua",
                Latitude = -8.045639,
                Longitude = -34.904331,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 631,
                Name = "Bueiro " + 631,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.104908,
                Longitude = -34.911083,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 632,
                Name = "Bueiro " + 632,
                Street = "Arquiteto Luis Nunes, Rua",
                Latitude = -8.095085,
                Longitude = -34.911600,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 633,
                Name = "Bueiro " + 633,
                Street = "Arquiteto Luis Nunes, Rua",
                Latitude = -8.096028,
                Longitude = -34.911796,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 634,
                Name = "Bueiro " + 634,
                Street = "Arquiteto Luis Nunes, Rua",
                Latitude = -8.098032,
                Longitude = -34.912281,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 635,
                Name = "Bueiro " + 635,
                Street = "Arquiteto Luis Nunes, Rua",
                Latitude = 8.015170,
                Longitude = -34.912952,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 636,
                Name = "Bueiro " + 636,
                Street = "Rua Paris",
                Latitude = -8.105941,
                Longitude = -34.913711,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 637,
                Name = "Bueiro " + 637,
                Street = "Arquiteto Luis Nunes, Rua",
                Latitude = -8.104876,
                Longitude = -34.91351,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 640,
                Name = "Bueiro " + 640,
                Street = "Mac. Arthur, Av. Gal.",
                Latitude = -8.110396,
                Longitude = -34.906276,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 641,
                Name = "Bueiro " + 641,
                Street = "Uriel de Holanda, Rua",
                Latitude = -8.008529,
                Longitude = -34.904465,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 642,
                Name = "Bueiro " + 642,
                Street = "Jerônimo Vilela, Rua",
                Latitude = -8.024514,
                Longitude = -34.882922,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 643,
                Name = "Bueiro " + 643,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.026861,
                Longitude = -34.904560,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 644,
                Name = "Bueiro " + 644,
                Street = "Barão de Souza Leão, Rua",
                Latitude = -8.133081,
                Longitude = -34.913173,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 645,
                Name = "Bueiro " + 645,
                Street = "Luis Correia de Brito, Av.",
                Latitude = -8.024768,
                Longitude = -34.874983,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 646,
                Name = "Bueiro " + 646,
                Street = "17 de Agosto, Av.",
                Latitude = -8.030863,
                Longitude = -34.924507,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 647,
                Name = "Bueiro " + 647,
                Street = "do Arraial, Estrada",
                Latitude = -8.027678,
                Longitude = -34.924486,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 648,
                Name = "Bueiro " + 648,
                Street = "Antônio Falcão, Rua",
                Latitude = -8.113374,
                Longitude = -34.900106,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 649,
                Name = "Bueiro " + 649,
                Street = "João Tude de Melo, Rua",
                Latitude = -8.035838,
                Longitude = -34.909644,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 650,
                Name = "Bueiro " + 650,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.054795,
                Longitude = -34.897674,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 651,
                Name = "Bueiro " + 651,
                Street = "Rua João Sales de Menezes",
                Latitude = -8.039950,
                Longitude = -34.944695,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 652,
                Name = "Bueiro " + 652,
                Street = "Av. Mário Álvares Pereira de Lyra",
                Latitude = -8.047018,
                Longitude = -34.936019,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 653,
                Name = "Bueiro " + 653,
                Street = "Rua Estado de Israel",
                Latitude = -8.062788,
                Longitude = -34.895284,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 654,
                Name = "Bueiro " + 654,
                Street = "Av. São Paulo",
                Latitude = -8.082019,
                Longitude = -34.939725,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 655,
                Name = "Bueiro " + 655,
                Street = "Estrada das Ubaias",
                Latitude = -8.029123,
                Longitude = -34.917341,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 656,
                Name = "Bueiro " + 656,
                Street = "Rua Antonio de Góes",
                Latitude = -8.085030,
                Longitude = -34.887150,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 657,
                Name = "Bueiro " + 657,
                Street = "Av. Herculano Bandeira",
                Latitude = -8.085877,
                Longitude = -34.888019,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 658,
                Name = "Bueiro " + 658,
                Street = "Av. Republica Árabe Unida",
                Latitude = -8.086776,
                Longitude = -34.888969,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 659,
                Name = "Bueiro " + 659,
                Street = "Rua Manoel de Brito",
                Latitude = -8.087144,
                Longitude = -34.888434,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 660,
                Name = "Bueiro " + 660,
                Street = "Av. Herculano Bandeira",
                Latitude = -8.085393,
                Longitude = -34.888464,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 661,
                Name = "Bueiro " + 661,
                Street = "Largo do Cabanga (sent. B. Viagem)",
                Latitude = -8.079534,
                Longitude = -34.892795,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 662,
                Name = "Bueiro " + 662,
                Street = "Largo do Cabanga (sent. B. Viagem)",
                Latitude = -8.080363,
                Longitude = -34.892198,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 663,
                Name = "Bueiro " + 663,
                Street = "Boa Viagem, Av.",
                Latitude = -8.110297,
                Longitude = -34.889290,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });

            return mocks;
        }

    }
}
