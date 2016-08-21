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
                    if (gasAlert && m.GasState != EImportanceState.Normal)
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
                Id = 1,
                Name = "Bueiro " + 1,
                Street = "Boa Viagem, Av.",
                Latitude = -8.142323,
                Longitude = -34.9037,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 3,
                Name = "Bueiro " + 3,
                Street = "Boa Viagem, Av.",
                Latitude = -8.106806,
                Longitude = -34.8877,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 4,
                Name = "Bueiro " + 4,
                Street = "Boa Viagem, Av.",
                Latitude = -8.132230,
                Longitude = -34.8999,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 5,
                Name = "Bueiro " + 5,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.104310,
                Longitude = -34.8882,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 6,
                Name = "Bueiro " + 6,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.116171,
                Longitude = -34.8946,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 7,
                Name = "Bueiro " + 7,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.107621,
                Longitude = -34.9116,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 8,
                Name = "Bueiro " + 8,
                Street = "Caxangá, Av.",
                Latitude = -8.040820,
                Longitude = -34.9384,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 9,
                Name = "Bueiro " + 9,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.044224,
                Longitude = -34.8745,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 10,
                Name = "Bueiro " + 10,
                Street = "II Perimetral",
                Latitude = -8.034731,
                Longitude = -34.90830,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 11,
                Name = "Bueiro " + 11,
                Street = "Conselheiro Portela, Rua",
                Latitude = -8.041458,
                Longitude = -34.89381,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 12,
                Name = "Bueiro " + 12,
                Street = "Barão da Vitória, Rua",
                Latitude = -8.067321,
                Longitude = -34.88293,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 13,
                Name = "Bueiro " + 13,
                Street = "Sol, Rua do",
                Latitude = -8.063874,
                Longitude = -34.88092,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 14,
                Name = "Bueiro " + 14,
                Street = "Sol, Rua do",
                Latitude = -8.062706,
                Longitude = -34.88041,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 15,
                Name = "Bueiro " + 15,
                Street = "Dantas Barreto, Av.",
                Latitude = -8.063788,
                Longitude = -34.87851,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 16,
                Name = "Bueiro " + 16,
                Street = "Recife, Av.",
                Latitude = -8.106969,
                Longitude = -34.92722,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 17,
                Name = "Bueiro " + 17,
                Street = "Nossa Senhora do Carmo, Av.",
                Latitude = -8.066200,
                Longitude = -34.87731,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 18,
                Name = "Bueiro " + 18,
                Street = "Imperador, Rua do",
                Latitude = -8.064191,
                Longitude = -34.87682,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 19,
                Name = "Bueiro " + 19,
                Street = "Rio Branco, Av.",
                Latitude = -8.062391,
                Longitude = -34.87383,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 20,
                Name = "Bueiro " + 20,
                Street = "Marquez de Olinda, Av.",
                Latitude = -8.063611,
                Longitude = -34.87367,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 21,
                Name = "Bueiro " + 21,
                Street = "Hora, Rua da",
                Latitude = -8.042905,
                Longitude = -34.89193,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 22,
                Name = "Bueiro " + 22,
                Street = "Princesa Isabel, Rua",
                Latitude = -8.059518,
                Longitude = -34.87998,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 23,
                Name = "Bueiro " + 23,
                Street = "Conde da Boa Vista, Av.",
                Latitude = -8.060773,
                Longitude = -34.88405,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 24,
                Name = "Bueiro " + 24,
                Street = "Conde da Boa Vista, Av.",
                Latitude = -8.059567,
                Longitude = -34.88644,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 25,
                Name = "Bueiro " + 25,
                Street = "Conde da Boa Vista, Av.",
                Latitude = -8.057554,
                Longitude = -34.88996,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 26,
                Name = "Bueiro " + 26,
                Street = "Belém, Estrada de",
                Latitude = -8.032111,
                Longitude = -34.88132,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 27,
                Name = "Bueiro " + 27,
                Street = "Conde da Boa Vista, Av.",
                Latitude = -8.055998,
                Longitude = -34.89538,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 28,
                Name = "Bueiro " + 28,
                Street = "Manoel Borba, Av.",
                Latitude = -8.059392,
                Longitude = -34.89405,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 29,
                Name = "Bueiro " + 29,
                Street = "Manoel Borba, Av.",
                Latitude = -8.060502,
                Longitude = -34.88836,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 30,
                Name = "Bueiro " + 30,
                Street = "13 de Maio, Rua",
                Latitude = -8.052560,
                Longitude = -34.88369,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 31,
                Name = "Bueiro " + 31,
                Street = "Hospício, Rua do",
                Latitude = -8.057835,
                Longitude = -34.88298,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 32,
                Name = "Bueiro " + 32,
                Street = "Hospício, Rua do",
                Latitude = -8.055068,
                Longitude = -34.88226,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 33,
                Name = "Bueiro " + 33,
                Street = "Hospício, Rua do",
                Latitude = -8.062624,
                Longitude = -34.88529,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 34,
                Name = "Bueiro " + 34,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.047535,
                Longitude = -34.87696,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 35,
                Name = "Bueiro " + 35,
                Street = "Dantas Barreto, Av.",
                Latitude = -8.072249,
                Longitude = -34.88414,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 36,
                Name = "Bueiro " + 36,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.045910,
                Longitude = -34.87908,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 37,
                Name = "Bueiro " + 37,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.052422,
                Longitude = -34.89575,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 38,
                Name = "Bueiro " + 38,
                Street = "Martin Luther King, Av.",
                Latitude = -8.069418,
                Longitude = -34.89527,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 39,
                Name = "Bueiro " + 39,
                Street = "Motocolombó, Rua",
                Latitude = -8.082688,
                Longitude = -34.90662,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 40,
                Name = "Bueiro " + 40,
                Street = "Derby, Praça do",
                Latitude = -8.057073,
                Longitude = -34.90007,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 41,
                Name = "Bueiro " + 41,
                Street = "Príncipe, Rua do",
                Latitude = -8.057352,
                Longitude = -34.88506,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 42,
                Name = "Bueiro " + 42,
                Street = "Beberibe, Av.",
                Latitude = -8.037235,
                Longitude = -34.89099,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 43,
                Name = "Bueiro " + 43,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.038574,
                Longitude = -34.89200,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 44,
                Name = "Bueiro " + 44,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.091724,
                Longitude = -34.93607,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 45,
                Name = "Bueiro " + 45,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.037027,
                Longitude = -34.89434,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 46,
                Name = "Bueiro " + 46,
                Street = "Conselheiro Rosa e Silva, Av.",
                Latitude = -8.045446,
                Longitude = -34.89704,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 47,
                Name = "Bueiro " + 47,
                Street = "Conselheiro Rosa e Silva, Av.",
                Latitude = -8.039546,
                Longitude = -34.89940,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 48,
                Name = "Bueiro " + 48,
                Street = "Rui Barbosa, Av.",
                Latitude = -8.045144,
                Longitude = -34.90206,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 49,
                Name = "Bueiro " + 49,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.039799,
                Longitude = -34.87883,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 50,
                Name = "Bueiro " + 50,
                Street = "José Osório, Rua",
                Latitude = -8.053295,
                Longitude = -34.90671,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 51,
                Name = "Bueiro " + 51,
                Street = "Benfica, Rua",
                Latitude = -8.058950,
                Longitude = -34.90723,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 52,
                Name = "Bueiro " + 52,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.061707,
                Longitude = -34.90759,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 53,
                Name = "Bueiro " + 53,
                Street = "São Miguel, Rua",
                Latitude = -8.080270,
                Longitude = -34.90658,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 54,
                Name = "Bueiro " + 54,
                Street = "Dantas Barreto, Av.",
                Latitude = -8.070171,
                Longitude = -34.88231,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 55,
                Name = "Bueiro " + 55,
                Street = "Recife, Av.",
                Latitude = -8.107911,
                Longitude = -34.92709,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 56,
                Name = "Bueiro " + 56,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.039898,
                Longitude = -34.88752,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 57,
                Name = "Bueiro " + 57,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.062552,
                Longitude = -34.91311,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 58,
                Name = "Bueiro " + 58,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.060488,
                Longitude = -34.92571,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 59,
                Name = "Bueiro " + 59,
                Street = "Recife, Av.",
                Latitude = -8.094007,
                Longitude = -34.92904,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 60,
                Name = "Bueiro " + 60,
                Street = "Vincente Gomes,  Rua Dr.",
                Latitude = -8.133058,
                Longitude = -34.90175,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 61,
                Name = "Bueiro " + 61,
                Street = "Arraial, Estrada do",
                Latitude = -8.033199,
                Longitude = -34.90351,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 62,
                Name = "Bueiro " + 62,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.029633,
                Longitude = -34.90049,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 63,
                Name = "Bueiro " + 63,
                Street = "Beberibe, Av.",
                Latitude = -8.030124,
                Longitude = -34.89247,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 64,
                Name = "Bueiro " + 64,
                Street = "Beberibe, Av.",
                Latitude = -8.023192,
                Longitude = -34.89389,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 65,
                Name = "Bueiro " + 65,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.019908,
                Longitude = -34.92667,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 66,
                Name = "Bueiro " + 66,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.020799,
                Longitude = -34.92171,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 67,
                Name = "Bueiro " + 67,
                Street = "San Martin, Av. Gal.",
                Latitude = -8.055486,
                Longitude = -34.92396,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 68,
                Name = "Bueiro " + 68,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.058912,
                Longitude = -34.89793,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 69,
                Name = "Bueiro " + 69,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.062523,
                Longitude = -34.89754,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 70,
                Name = "Bueiro " + 70,
                Street = "Jean Emile Favre, Rua",
                Latitude = -8.113264,
                Longitude = -34.92208,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 71,
                Name = "Bueiro " + 71,
                Street = "Joaquim Nabuco, Rua",
                Latitude = -8.052473,
                Longitude = -34.89947,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 72,
                Name = "Bueiro " + 72,
                Street = "Sul, Av.",
                Latitude = -8.072364,
                Longitude = -34.88047,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 73,
                Name = "Bueiro " + 73,
                Street = "Nicolau Pereira, Rua",
                Latitude = -8.079545,
                Longitude = -34.90433,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 74,
                Name = "Bueiro " + 74,
                Street = "Arraial, Estrada do",
                Latitude = -8.027477,
                Longitude = -34.91385,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 75,
                Name = "Bueiro " + 75,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.056709,
                Longitude = -34.89792,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 76,
                Name = "Bueiro " + 76,
                Street = "Santa Rita, Cais de",
                Latitude = -8.069600,
                Longitude = -34.87539,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 77,
                Name = "Bueiro " + 77,
                Street = "Beira Rio, Av.",
                Latitude = -8.046546,
                Longitude = -34.90422,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 78,
                Name = "Bueiro " + 78,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.048678,
                Longitude = -34.89294,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 79,
                Name = "Bueiro " + 79,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.024091,
                Longitude = -34.91192,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 80,
                Name = "Bueiro " + 80,
                Street = "Caxangá, Av.",
                Latitude = -8.050447,
                Longitude = -34.92107,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 81,
                Name = "Bueiro " + 81,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.033536,
                Longitude = -34.89647,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 82,
                Name = "Bueiro " + 82,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.084694,
                Longitude = -34.92812,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 83,
                Name = "Bueiro " + 83,
                Street = "Manoel Borba, Av.",
                Latitude = -8.059303,
                Longitude = -34.89131,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 84,
                Name = "Bueiro " + 84,
                Street = "Boa Viagem, Av.",
                Latitude = -8.151128,
                Longitude = -34.90778,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 85,
                Name = "Bueiro " + 85,
                Street = "Recife, Av.",
                Latitude = -8.092779,
                Longitude = -34.92926,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 86,
                Name = "Bueiro " + 86,
                Street = "Barão de Itamaracá, Rua",
                Latitude = -8.043457,
                Longitude = -34.89335,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 87,
                Name = "Bueiro " + 87,
                Street = "Imperial, Rua",
                Latitude = -8.076451,
                Longitude = -34.89594,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 88,
                Name = "Bueiro " + 88,
                Street = "Maurício de Nassau, Av.",
                Latitude = -8.040724,
                Longitude = -34.92719,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 89,
                Name = "Bueiro " + 89,
                Street = "João de Barros, Av.",
                Latitude = -8.041333,
                Longitude = -34.89143,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 90,
                Name = "Bueiro " + 90,
                Street = "Aurora, Rua da",
                Latitude = -8.056323,
                Longitude = -34.87795,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 91,
                Name = "Bueiro " + 91,
                Street = "Falcão de Lacerda, Rua",
                Latitude = -8.093354,
                Longitude = -34.96375,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 92,
                Name = "Bueiro " + 92,
                Street = "Hospício, Rua do",
                Latitude = -8.059149,
                Longitude = -34.88349,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 93,
                Name = "Bueiro " + 93,
                Street = "Álvares de Azevedo, Rua",
                Latitude = -8.049570,
                Longitude = -34.88867,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 94,
                Name = "Bueiro " + 94,
                Street = "Belém, Estrada de",
                Latitude = -8.032989,
                Longitude = -34.88456,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 95,
                Name = "Bueiro " + 95,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.021323,
                Longitude = -34.91748,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 96,
                Name = "Bueiro " + 96,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.025589,
                Longitude = -34.90658,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 97,
                Name = "Bueiro " + 97,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.043957,
                Longitude = -34.88241,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 98,
                Name = "Bueiro " + 98,
                Street = "Santos Dumont, Av.",
                Latitude = -8.035649,
                Longitude = -34.89748,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 99,
                Name = "Bueiro " + 99,
                Street = "Conselheiro Rosa e Silva, Av.",
                Latitude = -8.041708,
                Longitude = -34.89800,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 100,
                Name = "Bueiro " + 100,
                Street = "Bongi, Estrada Velha do",
                Latitude = -8.068287,
                Longitude = -34.909790,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 101,
                Name = "Bueiro " + 101,
                Street = "Jean Emile Favre, Rua",
                Latitude = -8.109943,
                Longitude = -34.918273,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 102,
                Name = "Bueiro " + 102,
                Street = "Rui Barbosa, Av.",
                Latitude = -8.049903,
                Longitude = -34.898007,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 103,
                Name = "Bueiro " + 103,
                Street = "Antônio de Góis, Av.",
                Latitude = -8.085444,
                Longitude = -34.886685,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 104,
                Name = "Bueiro " + 104,
                Street = "Boa Viagem, Av.",
                Latitude = -8.091769,
                Longitude = -34.882053,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 105,
                Name = "Bueiro " + 105,
                Street = "Boa Viagem, Av.",
                Latitude = -8.099740,
                Longitude = -34.884436,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 106,
                Name = "Bueiro " + 106,
                Street = "Real da Torre, Rua",
                Latitude = -8.046317,
                Longitude = -34.909548,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 107,
                Name = "Bueiro " + 107,
                Street = "17 de Agosto, Av.",
                Latitude = -8.027788,
                Longitude = -34.927156,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 108,
                Name = "Bueiro " + 108,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.043536,
                Longitude = -34.887514,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 109,
                Name = "Bueiro " + 109,
                Street = "Maurício de Nassau, Av.",
                Latitude = -8.039282,
                Longitude = -34.929594,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 110,
                Name = "Bueiro " + 110,
                Street = "Boa Viagem, Av.",
                Latitude = -8.095900,
                Longitude = -34.883112,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 111,
                Name = "Bueiro " + 111,
                Street = "Itanagé, Rua",
                Latitude = -8.106442,
                Longitude = -34.921326,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 112,
                Name = "Bueiro " + 112,
                Street = "Boa Viagem, Av.",
                Latitude = -8.120273,
                Longitude = -34.895078,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 113,
                Name = "Bueiro " + 113,
                Street = "Boa Viagem, Av.",
                Latitude = -8.125274,
                Longitude = -34.897142,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 114,
                Name = "Bueiro " + 114,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.129069,
                Longitude = -34.898560,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 115,
                Name = "Bueiro " + 115,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.120288,
                Longitude = -34.895068,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 116,
                Name = "Bueiro " + 116,
                Street = "Mascarenhas de Morais, Av. sentido Cid/Sub",
                Latitude = -8.125110,
                Longitude = -34.915075,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 117,
                Name = "Bueiro " + 117,
                Street = "Boa Viagem, Av.",
                Latitude = -8.108815,
                Longitude = -34.888605,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 118,
                Name = "Bueiro " + 118,
                Street = "Boa Viagem, Av.",
                Latitude = -8.101374,
                Longitude = -34.885168,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 119,
                Name = "Bueiro " + 119,
                Street = "Boa Viagem, Av.",
                Latitude = -8.094196,
                Longitude = -34.882681,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 120,
                Name = "Bueiro " + 120,
                Street = "Boa Viagem, Av.",
                Latitude = -8.121939,
                Longitude = -34.895997,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 121,
                Name = "Bueiro " + 121,
                Street = "Boa Viagem, Av.",
                Latitude = -8.098279,
                Longitude = -34.883756,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 122,
                Name = "Bueiro " + 122,
                Street = "Frei Matias Teves, Av.",
                Latitude = -8.063672,
                Longitude = -34.896197,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 123,
                Name = "Bueiro " + 123,
                Street = "Boa Viagem, Av.",
                Latitude = -8.111829,
                Longitude = -34.889969,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 124,
                Name = "Bueiro " + 124,
                Street = "Boa Viagem, Av.",
                Latitude = -8.104509,
                Longitude = -34.886665,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 125,
                Name = "Bueiro " + 125,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.114538,
                Longitude = -34.893663,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 126,
                Name = "Bueiro " + 126,
                Street = "Rui Barbosa, Av.",
                Latitude = -8.047637,
                Longitude = -34.899890,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 127,
                Name = "Bueiro " + 127,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.124892,
                Longitude = -34.899121,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 128,
                Name = "Bueiro " + 128,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.127933,
                Longitude = -34.901425,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 129,
                Name = "Bueiro " + 129,
                Street = "Visconde de Jequitinhonha, Av.",
                Latitude = -8.131572,
                Longitude = -34.902889,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 130,
                Name = "Bueiro " + 130,
                Street = "Recife, Av.",
                Latitude = -8.115394,
                Longitude = -34.924526,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 131,
                Name = "Bueiro " + 131,
                Street = "Beberibe, Av.",
                Latitude = -8.027954,
                Longitude = -34.892919,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 132,
                Name = "Bueiro " + 132,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.062088,
                Longitude = -34.909676,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 133,
                Name = "Bueiro " + 133,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.092824,
                Longitude = -34.883905,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 134,
                Name = "Bueiro " + 134,
                Street = "Mário Alves de Lira, Av.",
                Latitude = -8.046993,
                Longitude = -34.936048,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 136,
                Name = "Bueiro " + 136,
                Street = "Paula Batista, Rua",
                Latitude = -8.025550,
                Longitude = -34.915383,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 137,
                Name = "Bueiro " + 137,
                Street = "Herculano Bandeira, Rua",
                Latitude = -8.088874,
                Longitude = -34.885203,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 138,
                Name = "Bueiro " + 138,
                Street = "Herculano Bandeira, Rua",
                Latitude = -8.090466,
                Longitude = -34.883615,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 139,
                Name = "Bueiro " + 139,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.110533,
                Longitude = -34.892364,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 140,
                Name = "Bueiro " + 140,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.095521,
                Longitude = -34.884655,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 141,
                Name = "Bueiro " + 141,
                Street = "Dantas Barreto, Av.",
                Latitude = -8.062692,
                Longitude = -34.878243,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 142,
                Name = "Bueiro " + 142,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.095197,
                Longitude = -34.885913,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 143,
                Name = "Bueiro " + 143,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.110957,
                Longitude = -34.891519,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 144,
                Name = "Bueiro " + 144,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.114084,
                Longitude = -34.894511,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 145,
                Name = "Bueiro " + 145,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.115744,
                Longitude = -34.895531,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 146,
                Name = "Bueiro " + 146,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.121770,
                Longitude = -34.897939,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 147,
                Name = "Bueiro " + 147,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.123740,
                Longitude = -34.898664,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 148,
                Name = "Bueiro " + 148,
                Street = "Boa Viagem, Av.",
                Latitude = -8.137039,
                Longitude = -34.901918,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 149,
                Name = "Bueiro " + 149,
                Street = "Boa Viagem, Av.",
                Latitude = -8.145063,
                Longitude = -34.905147,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 150,
                Name = "Bueiro " + 150,
                Street = "Boa Viagem, Av.",
                Latitude = -8.148817,
                Longitude = -34.906892,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 151,
                Name = "Bueiro " + 151,
                Street = "Lins Pettit, Av.",
                Latitude = -8.060402,
                Longitude = -34.894791,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 152,
                Name = "Bueiro " + 152,
                Street = "Boa Viagem, Av.",
                Latitude = -8.129072,
                Longitude = -34.898562,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 153,
                Name = "Bueiro " + 153,
                Street = "Beberibe, Av.",
                Latitude = -8.017012,
                Longitude = -34.891978,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 154,
                Name = "Bueiro " + 154,
                Street = "Visconde de Jequitinhonha, Av.",
                Latitude = -8.144380,
                Longitude = -34.906482,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 155,
                Name = "Bueiro " + 155,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.123574,
                Longitude = -34.899789,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 156,
                Name = "Bueiro " + 156,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.091613,
                Longitude = -34.949282,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 157,
                Name = "Bueiro " + 157,
                Street = "Aprígio Guimarães, Rua",
                Latitude = -8.087130,
                Longitude = -34.965563,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 158,
                Name = "Bueiro " + 158,
                Street = "Visconde de Jequitinhonha, Av.",
                Latitude = -8.136528,
                Longitude = -34.903513,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 159,
                Name = "Bueiro " + 159,
                Street = "Barão de Souza Leão, Rua",
                Latitude = -8.132055,
                Longitude = -34.906769,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 160,
                Name = "Bueiro " + 160,
                Street = "dos Navegantes, Rua",
                Latitude = -8.121887,
                Longitude = -34.896770,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 161,
                Name = "Bueiro " + 161,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.106314,
                Longitude = -34.911444,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 162,
                Name = "Bueiro " + 162,
                Street = "Conde da Boa Vista, Av.",
                Latitude = -8.062052,
                Longitude = -34.881642,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 163,
                Name = "Bueiro " + 163,
                Street = "Dantas Barreto, Av.",
                Latitude = -8.064378,
                Longitude = -34.878424,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 164,
                Name = "Bueiro " + 164,
                Street = "Martins de Barros, Av.",
                Latitude = -8.061638,
                Longitude = -34.876530,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 165,
                Name = "Bueiro " + 165,
                Street = "Apolo, Cais do",
                Latitude = -8.063737,
                Longitude = -34.874422,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 166,
                Name = "Bueiro " + 166,
                Street = "Espinheiro, Rua do",
                Latitude = -8.042306,
                Longitude = -34.892561,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 167,
                Name = "Bueiro " + 167,
                Street = "Princesa Isabel, Rua",
                Latitude = -8.059131,
                Longitude = -34.880605,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 168,
                Name = "Bueiro " + 168,
                Street = "Princesa Isabel, Rua",
                Latitude = -8.058763,
                Longitude = -34.881174,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 169,
                Name = "Bueiro " + 169,
                Street = "Manoel Borba, Av.",
                Latitude = -8.061105,
                Longitude = -34.887367,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 170,
                Name = "Bueiro " + 170,
                Street = "Príncipe, Rua do",
                Latitude = -8.055811,
                Longitude = -34.887862,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 171,
                Name = "Bueiro " + 171,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.053960,
                Longitude = -34.881592,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 172,
                Name = "Bueiro " + 172,
                Street = "Visconde de Suassuna, Av.",
                Latitude = -8.053806,
                Longitude = -34.884457,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 173,
                Name = "Bueiro " + 173,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.051467,
                Longitude = -34.895077,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 174,
                Name = "Bueiro " + 174,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.053390,
                Longitude = -34.896415,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 175,
                Name = "Bueiro " + 175,
                Street = "Riachuelo, Rua do",
                Latitude = -8.058313,
                Longitude = -34.885652,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 176,
                Name = "Bueiro " + 176,
                Street = "Príncipe, Rua do",
                Latitude = -8.056649,
                Longitude = -34.886316,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 177,
                Name = "Bueiro " + 177,
                Street = "Amélia, Rua",
                Latitude = -8.045157,
                Longitude = -34.898335,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 178,
                Name = "Bueiro " + 178,
                Street = "Amélia, Rua",
                Latitude = -8.044977,
                Longitude = -34.900298,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 179,
                Name = "Bueiro " + 179,
                Street = "José Osório, Rua",
                Latitude = -8.053547,
                Longitude = -34.908646,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 180,
                Name = "Bueiro " + 180,
                Street = "Concórdia, Rua da",
                Latitude = -8.069743,
                Longitude = -34.882977,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 181,
                Name = "Bueiro " + 181,
                Street = "Dantas Barreto, Av.",
                Latitude = -8.071401,
                Longitude = -34.883221,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 182,
                Name = "Bueiro " + 182,
                Street = "Concórdia, Rua da",
                Latitude = -8.070961,
                Longitude = -34.883875,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 183,
                Name = "Bueiro " + 183,
                Street = "Fernando Simões Barbosa, Av.",
                Latitude = -8.119451,
                Longitude = -34.901152,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 184,
                Name = "Bueiro " + 184,
                Street = "Barão de Itamaracá, Rua",
                Latitude = -8.043834,
                Longitude = -34.892819,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 185,
                Name = "Bueiro " + 185,
                Street = "Gal. San Martin, Av.",
                Latitude = -8.052688,
                Longitude = -34.922385,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 186,
                Name = "Bueiro " + 186,
                Street = "Beberibe, Av.",
                Latitude = -8.036111,
                Longitude = -34.891244,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 187,
                Name = "Bueiro " + 187,
                Street = "Beberibe, Av.",
                Latitude = -8.018510,
                Longitude = -34.893277,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 188,
                Name = "Bueiro " + 188,
                Street = "Santos Dumont, Av.",
                Latitude = -8.040902,
                Longitude = -34.900096,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 189,
                Name = "Bueiro " + 189,
                Street = "Dom Manoel de Medeiros, Rua",
                Latitude = -8.015859,
                Longitude = -34.943677,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 190,
                Name = "Bueiro " + 190,
                Street = "Boa Viagem, Av.",
                Latitude = -8.146655,
                Longitude = -34.905891,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 191,
                Name = "Bueiro " + 191,
                Street = "José Bonifácio, Rua",
                Latitude = -8.046004,
                Longitude = -34.907050,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 192,
                Name = "Bueiro " + 192,
                Street = "Real da Torre, Rua",
                Latitude = -8.047506,
                Longitude = -34.909150,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 193,
                Name = "Bueiro " + 193,
                Street = "José Bonifácio, Rua",
                Latitude = -8.047199,
                Longitude = -34.906653,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 194,
                Name = "Bueiro " + 194,
                Street = "Martins de Barros, Av.",
                Latitude = -8.064105,
                Longitude = -34.876370,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 195,
                Name = "Bueiro " + 195,
                Street = "Amélia, Rua",
                Latitude = -8.045854,
                Longitude = -34.895336,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 196,
                Name = "Bueiro " + 196,
                Street = "Alfredo Lisboa, Av.",
                Latitude = -8.060701,
                Longitude = -34.870413,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 197,
                Name = "Bueiro " + 197,
                Street = "Sol, Rua do",
                Latitude = -8.061107,
                Longitude = -34.879324,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 198,
                Name = "Bueiro " + 198,
                Street = "João de Barros, Av.",
                Latitude = -8.049146,
                Longitude = -34.889967,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 199,
                Name = "Bueiro " + 199,
                Street = "São João, Rua de",
                Latitude = -8.071040,
                Longitude = -34.880820,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 200,
                Name = "Bueiro " + 200,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.098758,
                Longitude = -34.886600,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 201,
                Name = "Bueiro " + 201,
                Street = "Belém, Estrada de",
                Latitude = -8.035682,
                Longitude = -34.888540,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 202,
                Name = "Bueiro " + 202,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.040833,
                Longitude = -34.872134,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 203,
                Name = "Bueiro " + 203,
                Street = "Nossa Senhora do Carmo, Av.",
                Latitude = -8.066141,
                Longitude = -34.876680,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 204,
                Name = "Bueiro " + 204,
                Street = "Nossa Senhora do Carmo, Av.",
                Latitude = -8.066107,
                Longitude = -34.876245,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 205,
                Name = "Bueiro " + 205,
                Street = "Sul, Av. (Pista principal)",
                Latitude = -8.076835,
                Longitude = -34.894778,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 206,
                Name = "Bueiro " + 206,
                Street = "Imperador, Rua do",
                Latitude = -8.062875,
                Longitude = -34.876975,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 207,
                Name = "Bueiro " + 207,
                Street = "Imperial, Rua",
                Latitude = -8.071997,
                Longitude = -34.882352,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 208,
                Name = "Bueiro " + 208,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.090837,
                Longitude = -34.951214,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 209,
                Name = "Bueiro " + 209,
                Street = "José Mariano, Rua Dr.",
                Latitude = -8.064781,
                Longitude = -34.885037,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 210,
                Name = "Bueiro " + 210,
                Street = "Aurora, Rua da",
                Latitude = -8.063454,
                Longitude = -34.882531,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 211,
                Name = "Bueiro " + 211,
                Street = "Sul, Av. (corredor de ônibus)",
                Latitude = -8.076928,
                Longitude = -34.894710,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 212,
                Name = "Bueiro " + 212,
                Street = "Recife, Av.",
                Latitude = -8.103840,
                Longitude = -34.927694,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 213,
                Name = "Bueiro " + 213,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.092925,
                Longitude = -34.941609,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 214,
                Name = "Bueiro " + 214,
                Street = "Conselheiro Rosa e Silva, Av.",
                Latitude = -8.038142,
                Longitude = -34.900583,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 215,
                Name = "Bueiro " + 215,
                Street = "Futuro, Rua do",
                Latitude = -8.038757,
                Longitude = -34.901782,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 216,
                Name = "Bueiro " + 216,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.119076,
                Longitude = -34.897531,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 217,
                Name = "Bueiro " + 217,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.124700,
                Longitude = -34.900211,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 218,
                Name = "Bueiro " + 218,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.132591,
                Longitude = -34.916230,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 219,
                Name = "Bueiro " + 219,
                Street = "Odete Monteiro, Rua",
                Latitude = -8.045980,
                Longitude = -34.920842,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 220,
                Name = "Bueiro " + 220,
                Street = "Manoel Borba, Av.",
                Latitude = -8.059565,
                Longitude = -34.890071,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 221,
                Name = "Bueiro " + 221,
                Street = "Gervásio Pires, Rua",
                Latitude = -8.062029,
                Longitude = -34.887929,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 222,
                Name = "Bueiro " + 222,
                Street = "Soledade, Rua da",
                Latitude = -8.056245,
                Longitude = -34.889896,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 223,
                Name = "Bueiro " + 223,
                Street = "Padre Roma, Rua",
                Latitude = -8.033814,
                Longitude = -34.905615,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 224,
                Name = "Bueiro " + 224,
                Street = "Dom Manoel de Medeiros, Rua",
                Latitude = -8.016905,
                Longitude = -34.951408,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 225,
                Name = "Bueiro " + 225,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.108870,
                Longitude = -34.911830,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 226,
                Name = "Bueiro " + 226,
                Street = "Antônio de Góis, Av.",
                Latitude = -8.089550,
                Longitude = -34.882736,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 227,
                Name = "Bueiro " + 227,
                Street = "Antônio Falcão, Rua",
                Latitude = -8.115157,
                Longitude = -34.896684,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 228,
                Name = "Bueiro " + 228,
                Street = "Caxangá, Av.",
                Latitude = -8.034520,
                Longitude = -34.950005,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 229,
                Name = "Bueiro " + 229,
                Street = "Caxangá, Av.",
                Latitude = -8.041579,
                Longitude = -34.937045,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 230,
                Name = "Bueiro " + 230,
                Street = "Caxangá, Av.",
                Latitude = -8.037541,
                Longitude = -34.944343,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 231,
                Name = "Bueiro " + 231,
                Street = "Caxangá, Av.",
                Latitude = -8.036979,
                Longitude = -34.945456,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 232,
                Name = "Bueiro " + 232,
                Street = "Caxangá, Av.",
                Latitude = -8.032096,
                Longitude = -34.954246,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 233,
                Name = "Bueiro " + 233,
                Street = "Carlos Gomes, Rua",
                Latitude = -8.066040,
                Longitude = -34.914151,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 234,
                Name = "Bueiro " + 234,
                Street = "Caxangá, Av.",
                Latitude = -8.045539,
                Longitude = -34.929875,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 235,
                Name = "Bueiro " + 235,
                Street = "Caxangá, Av.",
                Latitude = -8.046686,
                Longitude = -34.927879,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 236,
                Name = "Bueiro " + 236,
                Street = "Caxangá, Av.",
                Latitude = -8.051658,
                Longitude = -34.918898,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 237,
                Name = "Bueiro " + 237,
                Street = "Real da Torre, Rua",
                Latitude = -8.055776,
                Longitude = -34.909047,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 238,
                Name = "Bueiro " + 238,
                Street = "Beberibe, Av.",
                Latitude = -8.034461,
                Longitude = -34.891581,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 239,
                Name = "Bueiro " + 239,
                Street = "São Mateus, Rua",
                Latitude = -8.036687,
                Longitude = -34.935337,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 240,
                Name = "Bueiro " + 240,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.102537,
                Longitude = -34.887433,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 241,
                Name = "Bueiro " + 241,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.126841,
                Longitude = -34.899838,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 242,
                Name = "Bueiro " + 242,
                Street = "Remédios, Estrada dos",
                Latitude = -8.075989,
                Longitude = -34.907286,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 243,
                Name = "Bueiro " + 243,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.049989,
                Longitude = -34.873799,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 244,
                Name = "Bueiro " + 244,
                Street = "Visconde de Suassuna, Av.",
                Latitude = -8.054486,
                Longitude = -34.883273,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 245,
                Name = "Bueiro " + 245,
                Street = "21 de Abril, Rua",
                Latitude = -8.075102,
                Longitude = -34.918391,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 246,
                Name = "Bueiro " + 246,
                Street = "Barbalho, Estrada do",
                Latitude = -8.035471,
                Longitude = -34.939850,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 247,
                Name = "Bueiro " + 247,
                Street = "Recife, Av.",
                Latitude = -8.116248,
                Longitude = -34.923724,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 248,
                Name = "Bueiro " + 248,
                Street = "Dois Irmãos, Av.",
                Latitude = -8.020731,
                Longitude = -34.935794,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 249,
                Name = "Bueiro " + 249,
                Street = "Forte, Av. do",
                Latitude = -8.053507,
                Longitude = -34.928933,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 250,
                Name = "Bueiro " + 250,
                Street = "Recife, Av.",
                Latitude = -8.091043,
                Longitude = -34.929478,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 251,
                Name = "Bueiro " + 251,
                Street = "17 de Agosto, Av.",
                Latitude = -8.029358,
                Longitude = -34.925824,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 252,
                Name = "Bueiro " + 252,
                Street = "Dom Manoel da Costa, Rua",
                Latitude = -8.047935,
                Longitude = -34.912448,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 253,
                Name = "Bueiro " + 253,
                Street = "Conselheiro Rosa e Silva, Av.",
                Latitude = -8.034683,
                Longitude = -34.902533,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 254,
                Name = "Bueiro " + 254,
                Street = "Bom Pastor, Rua do",
                Latitude = -8.041855,
                Longitude = -34.938849,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 255,
                Name = "Bueiro " + 255,
                Street = "Cais da Alfândega",
                Latitude = -8.065063,
                Longitude = -34.874110,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 256,
                Name = "Bueiro " + 256,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.020638,
                Longitude = -34.923509,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 257,
                Name = "Bueiro " + 257,
                Street = "Benfica, Rua",
                Latitude = -8.057092,
                Longitude = -34.909243,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 258,
                Name = "Bueiro " + 258,
                Street = "Visconde de Jequitinhonha, Av.",
                Latitude = -8.150556,
                Longitude = -34.909229,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 259,
                Name = "Bueiro " + 259,
                Street = "Recife, Av.",
                Latitude = -8.079617,
                Longitude = -34.933912,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 260,
                Name = "Bueiro " + 260,
                Street = "Sul, Av.",
                Latitude = -8.077861,
                Longitude = -34.897881,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 261,
                Name = "Bueiro " + 261,
                Street = "Recife, Av.",
                Latitude = -8.082634,
                Longitude = -34.932978,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 262,
                Name = "Bueiro " + 262,
                Street = "Caxangá, Av.",
                Latitude = -8.031644,
                Longitude = -34.954884,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 263,
                Name = "Bueiro " + 263,
                Street = "Caxangá, Av.",
                Latitude = -8.056418,
                Longitude = -34.910079,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 264,
                Name = "Bueiro " + 264,
                Street = "Caxangá, Av.",
                Latitude = -8.056584,
                Longitude = -34.910117,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 265,
                Name = "Bueiro " + 265,
                Street = "Caxangá, Av.",
                Latitude = -8.050146,
                Longitude = -34.921422,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 266,
                Name = "Bueiro " + 266,
                Street = "Caxangá, Av.",
                Latitude = -8.050299,
                Longitude = -34.921551,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 267,
                Name = "Bueiro " + 267,
                Street = "Caxangá, Av.",
                Latitude = -8.048130,
                Longitude = -34.925055,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 268,
                Name = "Bueiro " + 268,
                Street = "Caxangá, Av.",
                Latitude = -8.048288,
                Longitude = -34.925162,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 269,
                Name = "Bueiro " + 269,
                Street = "Caxangá, Av.",
                Latitude = -8.038388,
                Longitude = -34.942657,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 270,
                Name = "Bueiro " + 270,
                Street = "Caxangá, Av.",
                Latitude = -8.038523,
                Longitude = -34.942786,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 271,
                Name = "Bueiro " + 271,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.063964,
                Longitude = -34.935793,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 272,
                Name = "Bueiro " + 272,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.064074,
                Longitude = -34.935713,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 273,
                Name = "Bueiro " + 273,
                Street = "Caxangá, Av.",
                Latitude = -8.053311,
                Longitude = -34.915731,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 274,
                Name = "Bueiro " + 274,
                Street = "Caxangá, Av.",
                Latitude = -8.053461,
                Longitude = -34.915814,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 275,
                Name = "Bueiro " + 275,
                Street = "Caxangá, Av.",
                Latitude = -8.046260,
                Longitude = -34.928452,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 276,
                Name = "Bueiro " + 276,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.120813,
                Longitude = -34.914266,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 277,
                Name = "Bueiro " + 277,
                Street = "Antônio de Góis, Av.",
                Latitude = -8.087743,
                Longitude = -34.884504,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 278,
                Name = "Bueiro " + 278,
                Street = "República, Pça. da",
                Latitude = -8.061501,
                Longitude = -34.877182,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 279,
                Name = "Bueiro " + 279,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.086972,
                Longitude = -34.907580,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 280,
                Name = "Bueiro " + 280,
                Street = "Tomás Gonzaga, Rua",
                Latitude = -8.048433,
                Longitude = -34.919173,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 281,
                Name = "Bueiro " + 281,
                Street = "Joaquim Ribeiro, Av.",
                Latitude = -8.030013,
                Longitude = -34.958002,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 282,
                Name = "Bueiro " + 282,
                Street = "Jerônimo Vilela, Rua",
                Latitude = -8.028109,
                Longitude = -34.882152,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 283,
                Name = "Bueiro " + 283,
                Street = "Arraial, Estrada do",
                Latitude = -8.026721,
                Longitude = -34.916176,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 284,
                Name = "Bueiro " + 284,
                Street = "Nossa Senhora do Carmo, Av.",
                Latitude = -8.065891,
                Longitude = -34.879036,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 285,
                Name = "Bueiro " + 285,
                Street = "Falcão de Lacerda, Rua",
                Latitude = -8.092065,
                Longitude = -34.961480,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 286,
                Name = "Bueiro " + 286,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.088045,
                Longitude = -34.907803,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 287,
                Name = "Bueiro " + 287,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.096481,
                Longitude = -34.909728,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 288,
                Name = "Bueiro " + 288,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.098453,
                Longitude = -34.910102,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 289,
                Name = "Bueiro " + 289,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.115595,
                Longitude = -34.913309,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 290,
                Name = "Bueiro " + 290,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.116233,
                Longitude = -34.913346,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 291,
                Name = "Bueiro " + 291,
                Street = "Arraial, Estrada do",
                Latitude = -8.028431,
                Longitude = -34.910696,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 292,
                Name = "Bueiro " + 292,
                Street = "Rui Barbosa, Av.",
                Latitude = -8.039897,
                Longitude = -34.904022,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 294,
                Name = "Bueiro " + 294,
                Street = "Dom Bosco, Rua",
                Latitude = -8.058036,
                Longitude = -34.894590,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 295,
                Name = "Bueiro " + 295,
                Street = "Arraial, Estrada do",
                Latitude = -8.030112,
                Longitude = -34.907056,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 296,
                Name = "Bueiro " + 296,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.012567,
                Longitude = -34.931804,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 297,
                Name = "Bueiro " + 297,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.105434,
                Longitude = -34.889648,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 298,
                Name = "Bueiro " + 298,
                Street = "Ribeiro de Brito, Rua",
                Latitude = -8.122987,
                Longitude = -34.903879,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 299,
                Name = "Bueiro " + 299,
                Street = "Conde da Boa Vista, Av.",
                Latitude = -8.056664,
                Longitude = -34.892671,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 300,
                Name = "Bueiro " + 300,
                Street = "São Miguel, Rua",
                Latitude = -8.080315,
                Longitude = -34.908269,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 301,
                Name = "Bueiro " + 301,
                Street = "José Bonifácio, Rua",
                Latitude = -8.043492,
                Longitude = -34.907912,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 302,
                Name = "Bueiro " + 302,
                Street = "Imperial, Rua",
                Latitude = -8.075855,
                Longitude = -34.894062,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 303,
                Name = "Bueiro " + 303,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.101935,
                Longitude = -34.888044,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 304,
                Name = "Bueiro " + 304,
                Street = "Ernesto de Paula Santos, Rua",
                Latitude = -8.124081,
                Longitude = -34.903819,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 305,
                Name = "Bueiro " + 305,
                Street = "Rui Barbosa, Av.",
                Latitude = -8.043981,
                Longitude = -34.902188,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 306,
                Name = "Bueiro " + 306,
                Street = "Velha de Água Fria, Estrada",
                Latitude = -8.026749,
                Longitude = -34.897962,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 307,
                Name = "Bueiro " + 307,
                Street = "Beberibe, Av.",
                Latitude = -8.015017,
                Longitude = -34.890140,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 308,
                Name = "Bueiro " + 308,
                Street = "João Lira, Rua",
                Latitude = -8.056601,
                Longitude = -34.879851,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 309,
                Name = "Bueiro " + 309,
                Street = "Conselheiro Rosa e Silva, Av.",
                Latitude = -8.047866,
                Longitude = -34.896847,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 310,
                Name = "Bueiro " + 310,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.120907,
                Longitude = -34.914121,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 311,
                Name = "Bueiro " + 311,
                Street = "Sul, Av.",
                Latitude = -8.073372,
                Longitude = -34.885191,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 312,
                Name = "Bueiro " + 312,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.023829,
                Longitude = -34.912528,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 313,
                Name = "Bueiro " + 313,
                Street = "21 de Abril, Rua",
                Latitude = -8.072345,
                Longitude = -34.925366,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 314,
                Name = "Bueiro " + 314,
                Street = "Beberibe, Av.",
                Latitude = -8.004794,
                Longitude = -34.893625,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 316,
                Name = "Bueiro " + 316,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.087051,
                Longitude = -34.907504,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 317,
                Name = "Bueiro " + 317,
                Street = "Souza Bandeira, Rua",
                Latitude = -8.047588,
                Longitude = -34.917384,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 318,
                Name = "Bueiro " + 318,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.130807,
                Longitude = -34.901285,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 319,
                Name = "Bueiro " + 319,
                Street = "Recife, Av.",
                Latitude = -8.119429,
                Longitude = -34.920891,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 320,
                Name = "Bueiro " + 320,
                Street = "Sul, Av.",
                Latitude = -8.079511,
                Longitude = -34.902473,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 321,
                Name = "Bueiro " + 321,
                Street = "Padre Carapuceiro, Rua",
                Latitude = -8.117528,
                Longitude = -34.900801,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 322,
                Name = "Bueiro " + 322,
                Street = "Dez de Julho, Rua",
                Latitude = -8.134524,
                Longitude = -34.914772,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 323,
                Name = "Bueiro " + 323,
                Street = "Dois Rios, Av.",
                Latitude = -8.116596,
                Longitude = -34.941130,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 324,
                Name = "Bueiro " + 324,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.099950,
                Longitude = -34.887130,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 325,
                Name = "Bueiro " + 325,
                Street = "Dois Rios, Av.",
                Latitude = -8.113534,
                Longitude = -34.938989,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 326,
                Name = "Bueiro " + 326,
                Street = "San Martin, Av. Gal.",
                Latitude = -8.065287,
                Longitude = -34.927227,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 327,
                Name = "Bueiro " + 327,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.062513,
                Longitude = -34.917033,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 328,
                Name = "Bueiro " + 328,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.062363,
                Longitude = -34.917038,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 329,
                Name = "Bueiro " + 329,
                Street = "Ernesto de Paula Santos, Rua",
                Latitude = -8.124460,
                Longitude = -34.901516,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 330,
                Name = "Bueiro " + 330,
                Street = "Ernesto de Paula Santos, Rua",
                Latitude = -8.124127,
                Longitude = -34.905228,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 331,
                Name = "Bueiro " + 331,
                Street = "Ribeiro de Brito, Rua",
                Latitude = -8.122961,
                Longitude = -34.905213,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 332,
                Name = "Bueiro " + 332,
                Street = "Ribeiro de Brito, Rua",
                Latitude = -8.123331,
                Longitude = -34.901447,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 333,
                Name = "Bueiro " + 333,
                Street = "São Miguel, Rua",
                Latitude = -8.080316,
                Longitude = -34.909456,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 334,
                Name = "Bueiro " + 334,
                Street = "21 de Abril, Rua",
                Latitude = -8.076993,
                Longitude = -34.909194,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 335,
                Name = "Bueiro " + 335,
                Street = "Fernando Simões Barbosa, Av.",
                Latitude = -8.121371,
                Longitude = -34.901309,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 336,
                Name = "Bueiro " + 336,
                Street = "Recife, Av.",
                Latitude = -8.100611,
                Longitude = -34.928171,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 337,
                Name = "Bueiro " + 337,
                Street = "Recife, Av.",
                Latitude = -8.112517,
                Longitude = -34.926508,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 338,
                Name = "Bueiro " + 338,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.121631,
                Longitude = -34.899050,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 339,
                Name = "Bueiro " + 339,
                Street = "João de Barros, Av.",
                Latitude = -8.042850,
                Longitude = -34.890702,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 340,
                Name = "Bueiro " + 340,
                Street = "Apolo, Cais do",
                Latitude = -8.054344,
                Longitude = -34.871957,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 341,
                Name = "Bueiro " + 341,
                Street = "Jerônimo Vilela, Rua",
                Latitude = -8.025460,
                Longitude = -34.882737,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 342,
                Name = "Bueiro " + 342,
                Street = "Cônego Barata, Rua",
                Latitude = -8.032146,
                Longitude = -34.902614,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 343,
                Name = "Bueiro " + 343,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.044646,
                Longitude = -34.874888,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 344,
                Name = "Bueiro " + 344,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.043294,
                Longitude = -34.873933,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 345,
                Name = "Bueiro " + 345,
                Street = "17 de Agosto, Av.",
                Latitude = -8.036436,
                Longitude = -34.913909,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 346,
                Name = "Bueiro " + 346,
                Street = "17 de Agosto, Av.",
                Latitude = -8.037138,
                Longitude = -34.914591,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 347,
                Name = "Bueiro " + 347,
                Street = "Cônego Barata, Rua",
                Latitude = -8.032199,
                Longitude = -34.902509,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 348,
                Name = "Bueiro " + 348,
                Street = "Carlos Gomes, Rua",
                Latitude = -8.059004,
                Longitude = -34.911957,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 349,
                Name = "Bueiro " + 349,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.063700,
                Longitude = -34.897595,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 350,
                Name = "Bueiro " + 350,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.063725,
                Longitude = -34.897695,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 351,
                Name = "Bueiro " + 351,
                Street = "Dois Rios, Av.",
                Latitude = -8.117766,
                Longitude = -34.941927,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 352,
                Name = "Bueiro " + 352,
                Street = "Imperial, Rua",
                Latitude = -8.077527,
                Longitude = -34.899322,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 353,
                Name = "Bueiro " + 353,
                Street = "José Gonçalves de Medeiros, Rua",
                Latitude = -8.058948,
                Longitude = -34.907222,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 354,
                Name = "Bueiro " + 354,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.062577,
                Longitude = -34.911677,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 355,
                Name = "Bueiro " + 355,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.061118,
                Longitude = -34.904854,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 356,
                Name = "Bueiro " + 356,
                Street = "João de Barros, Av.",
                Latitude = -8.050213,
                Longitude = -34.889948,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 357,
                Name = "Bueiro " + 357,
                Street = "Odorico Mendes, Rua",
                Latitude = -8.035389,
                Longitude = -34.880524,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 358,
                Name = "Bueiro " + 358,
                Street = "Parnamirim, Pça.",
                Latitude = -8.033040,
                Longitude = -34.910404,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 359,
                Name = "Bueiro " + 359,
                Street = "Coelhos, Rua dos",
                Latitude = -8.066612,
                Longitude = -34.889726,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 360,
                Name = "Bueiro " + 360,
                Street = "Alberto Paiva, Rua",
                Latitude = -8.043870,
                Longitude = -34.900388,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 361,
                Name = "Bueiro " + 361,
                Street = "Hora, Rua da",
                Latitude = -8.046217,
                Longitude = -34.894335,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 362,
                Name = "Bueiro " + 362,
                Street = "Regueira Costa, Rua",
                Latitude = -8.035400,
                Longitude = -34.898450,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 363,
                Name = "Bueiro " + 363,
                Street = "Moças, Rua das",
                Latitude = -8.016591,
                Longitude = -34.883967,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 364,
                Name = "Bueiro " + 364,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.026245,
                Longitude = -34.905490,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 365,
                Name = "Bueiro " + 365,
                Street = "João de Barros, Av.",
                Latitude = -8.053189,
                Longitude = -34.889967,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 366,
                Name = "Bueiro " + 366,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.106144,
                Longitude = -34.889082,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 367,
                Name = "Bueiro " + 367,
                Street = "Sport Club do Recife, Rua",
                Latitude = -8.061304,
                Longitude = -34.903875,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 368,
                Name = "Bueiro " + 368,
                Street = "Joaquim Ribeiro, Av.",
                Latitude = -8.030295,
                Longitude = -34.957363,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 369,
                Name = "Bueiro " + 369,
                Street = "Padre Lemos, Rua",
                Latitude = -8.022337,
                Longitude = -34.919695,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 370,
                Name = "Bueiro " + 370,
                Street = "17 de Agosto, Av.",
                Latitude = -8.027749,
                Longitude = -34.928219,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 371,
                Name = "Bueiro " + 371,
                Street = "San Martin, Av. Gal.",
                Latitude = -8.073416,
                Longitude = -34.929589,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 372,
                Name = "Bueiro " + 372,
                Street = "17 de Agosto, Av.",
                Latitude = -8.035731,
                Longitude = -34.920195,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 373,
                Name = "Bueiro " + 373,
                Street = "Joaquim Inácio, Av. Gal.",
                Latitude = -8.062569,
                Longitude = -34.896540,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 374,
                Name = "Bueiro " + 374,
                Street = "Luiz Freire, Av. Professor",
                Latitude = -8.058509,
                Longitude = -34.949579,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 375,
                Name = "Bueiro " + 375,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.062545,
                Longitude = -34.932194,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 376,
                Name = "Bueiro " + 376,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.040395,
                Longitude = -34.886885,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 377,
                Name = "Bueiro " + 377,
                Street = "Marechal Deodoro, Rua",
                Latitude = -8.039653,
                Longitude = -34.887309,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 378,
                Name = "Bueiro " + 378,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.041235,
                Longitude = -34.881592,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 379,
                Name = "Bueiro " + 379,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.040896,
                Longitude = -34.881825,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 380,
                Name = "Bueiro " + 380,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.105440,
                Longitude = -34.889651,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 381,
                Name = "Bueiro " + 381,
                Street = "Dantas Barreto, Av.",
                Latitude = -8.067750,
                Longitude = -34.880055,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 382,
                Name = "Bueiro " + 382,
                Street = "Dantas Barreto, Av.",
                Latitude = -8.067598,
                Longitude = -34.880289,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 383,
                Name = "Bueiro " + 383,
                Street = "Santa Rita, Cais de",
                Latitude = -8.067341,
                Longitude = -34.875618,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 384,
                Name = "Bueiro " + 384,
                Street = "Dantas Barreto, Av.",
                Latitude = -8.069285,
                Longitude = -34.881638,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 385,
                Name = "Bueiro " + 385,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.112542,
                Longitude = -34.912620,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 386,
                Name = "Bueiro " + 386,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.111426,
                Longitude = -34.912393,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 387,
                Name = "Bueiro " + 387,
                Street = "Beira Rio, Av.",
                Latitude = -8.053042,
                Longitude = -34.904730,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 388,
                Name = "Bueiro " + 388,
                Street = "Beberibe, Av.",
                Latitude = -8.009337,
                Longitude = -34.889131,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 389,
                Name = "Bueiro " + 389,
                Street = "17 de Agosto, Av.",
                Latitude = -8.037942,
                Longitude = -34.918009,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 390,
                Name = "Bueiro " + 390,
                Street = "Remédios, Estrada dos",
                Latitude = -8.065242,
                Longitude = -34.908034,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 391,
                Name = "Bueiro " + 391,
                Street = "São Miguel, Rua",
                Latitude = -8.080499,
                Longitude = -34.912906,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 392,
                Name = "Bueiro " + 392,
                Street = "São Miguel, Rua",
                Latitude = -8.080911,
                Longitude = -34.919408,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 393,
                Name = "Bueiro " + 393,
                Street = "Recife, Av.",
                Latitude = -8.120308,
                Longitude = -34.919456,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 394,
                Name = "Bueiro " + 394,
                Street = "Bongi, Estrada Velha do",
                Latitude = -8.068958,
                Longitude = -34.908466,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 395,
                Name = "Bueiro " + 395,
                Street = "Lindolfo Collor, Rua",
                Latitude = -8.052412,
                Longitude = -34.941340,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 396,
                Name = "Bueiro " + 396,
                Street = "Olívia Menelau, Rua",
                Latitude = -8.091147,
                Longitude = -34.908513,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 397,
                Name = "Bueiro " + 397,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.044930,
                Longitude = -34.880372,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 398,
                Name = "Bueiro " + 398,
                Street = "Beberibe, Av.",
                Latitude = -8.004310,
                Longitude = -34.896800,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 399,
                Name = "Bueiro " + 399,
                Street = "Arquiteto Luis Nunes, Rua",
                Latitude = -8.086460,
                Longitude = -34.909649,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 401,
                Name = "Bueiro " + 401,
                Street = "Dom Bosco, Rua",
                Latitude = -8.057437,
                Longitude = -34.894809,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 402,
                Name = "Bueiro " + 402,
                Street = "Mac. Arthur, Av. Gal.",
                Latitude = -8.109790,
                Longitude = -34.907568,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 403,
                Name = "Bueiro " + 403,
                Street = "San Martin, Av. Gal.",
                Latitude = -8.058427,
                Longitude = -34.925094,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 404,
                Name = "Bueiro " + 404,
                Street = "Arraial, Estrada do",
                Latitude = -8.026759,
                Longitude = -34.917731,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 405,
                Name = "Bueiro " + 405,
                Street = "Beberibe, Av.",
                Latitude = -8.019664,
                Longitude = -34.894550,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 406,
                Name = "Bueiro " + 406,
                Street = "Futuro, Rua do",
                Latitude = -8.036082,
                Longitude = -34.903974,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 407,
                Name = "Bueiro " + 407,
                Street = "Barão de Souza Leão, Rua",
                Latitude = -8.132167,
                Longitude = -34.907281,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 408,
                Name = "Bueiro " + 408,
                Street = "Concórdia, Rua da",
                Latitude = -8.071999,
                Longitude = -34.884642,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 409,
                Name = "Bueiro " + 409,
                Street = "Conde de Irajá, Rua",
                Latitude = -8.047001,
                Longitude = -34.913636,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 410,
                Name = "Bueiro " + 410,
                Street = "17 de Agosto, Av.",
                Latitude = -8.032824,
                Longitude = -34.923126,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 411,
                Name = "Bueiro " + 411,
                Street = "Falcão de Lacerda, Rua",
                Latitude = -8.091702,
                Longitude = -34.960211,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 412,
                Name = "Bueiro " + 412,
                Street = "João de Barros, Av.",
                Latitude = -8.046496,
                Longitude = -34.889856,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 413,
                Name = "Bueiro " + 413,
                Street = "Visconde de Albuquerque, Av.",
                Latitude = -8.052039,
                Longitude = -34.906643,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 414,
                Name = "Bueiro " + 414,
                Street = "Imperial, Rua",
                Latitude = -8.071947,
                Longitude = -34.882129,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 415,
                Name = "Bueiro " + 415,
                Street = "17 de Agosto, Av.",
                Latitude = -8.034731,
                Longitude = -34.911633,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 416,
                Name = "Bueiro " + 416,
                Street = "Dois Irmãos, Av.",
                Latitude = -8.016837,
                Longitude = -34.940941,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 417,
                Name = "Bueiro " + 417,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.057480,
                Longitude = -34.898221,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 418,
                Name = "Bueiro " + 418,
                Street = "Derby, Pça. (pista Sul)",
                Latitude = -8.057518,
                Longitude = -34.900070,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 419,
                Name = "Bueiro " + 419,
                Street = "Conselheiro Aguiar, Av.",
                Latitude = -8.132069,
                Longitude = -34.901564,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 420,
                Name = "Bueiro " + 420,
                Street = "Capitão Zuzinha, Rua",
                Latitude = -8.134801,
                Longitude = -34.906262,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 421,
                Name = "Bueiro " + 421,
                Street = "Arraial, Estrada do",
                Latitude = -8.031005,
                Longitude = -34.905445,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 422,
                Name = "Bueiro " + 422,
                Street = "Abdias de Carvalho, Av.",
                Latitude = -8.061639,
                Longitude = -34.930046,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 423,
                Name = "Bueiro " + 423,
                Street = "São Miguel, Rua",
                Latitude = -8.080699,
                Longitude = -34.914588,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 424,
                Name = "Bueiro " + 424,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.018246,
                Longitude = -34.928354,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 425,
                Name = "Bueiro " + 425,
                Street = "São Miguel, Rua",
                Latitude = -8.081510,
                Longitude = -34.922600,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 426,
                Name = "Bueiro " + 426,
                Street = "Cosme Viana, Rua",
                Latitude = -8.075838,
                Longitude = -34.909021,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 428,
                Name = "Bueiro " + 428,
                Street = "13 de Maio, Rua",
                Latitude = -8.051091,
                Longitude = -34.882771,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 429,
                Name = "Bueiro " + 429,
                Street = "Aurora, Rua da",
                Latitude = -8.058434,
                Longitude = -34.879286,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 430,
                Name = "Bueiro " + 430,
                Street = "Cosme Viana, Rua",
                Latitude = -8.071477,
                Longitude = -34.909389,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 431,
                Name = "Bueiro " + 431,
                Street = "Alegre, Rua",
                Latitude = -8.021129,
                Longitude = -34.893056,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 432,
                Name = "Bueiro " + 432,
                Street = "Guilherme Pinto, Rua",
                Latitude = -8.052197,
                Longitude = -34.902136,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 433,
                Name = "Bueiro " + 433,
                Street = "Visconde de Jequitinhonha, Av.",
                Latitude = -8.133035,
                Longitude = -34.902852,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 434,
                Name = "Bueiro " + 434,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.090909,
                Longitude = -34.957331,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 435,
                Name = "Bueiro " + 435,
                Street = "Harmonia, Rua da",
                Latitude = -8.031533,
                Longitude = -34.915277,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 436,
                Name = "Bueiro " + 436,
                Street = "Apolo, Cais do",
                Latitude = -8.053540,
                Longitude = -34.871839,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 437,
                Name = "Bueiro " + 437,
                Street = "10 de Julho, Rua",
                Latitude = -8.135802,
                Longitude = -34.908452,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 438,
                Name = "Bueiro " + 438,
                Street = "Boa Viagem, Av.",
                Latitude = -8.135429,
                Longitude = -34.901386,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 439,
                Name = "Bueiro " + 439,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.106415,
                Longitude = -34.911255,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 440,
                Name = "Bueiro " + 440,
                Street = "Liberdade, Av.",
                Latitude = -8.081032,
                Longitude = -34.968542,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 441,
                Name = "Bueiro " + 441,
                Street = "Armindo Moura, Av.",
                Latitude = -8.148718,
                Longitude = -34.914016,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 442,
                Name = "Bueiro " + 442,
                Street = "Silvino Macedo, Rua Sgt.",
                Latitude = -8.112050,
                Longitude = -34.906685,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 443,
                Name = "Bueiro " + 443,
                Street = "Visconde de Jequitinhonha, Av.",
                Latitude = -8.130714,
                Longitude = -34.902615,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 444,
                Name = "Bueiro " + 444,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.130800,
                Longitude = -34.901295,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 445,
                Name = "Bueiro " + 445,
                Street = "Boa Viagem, Av.",
                Latitude = -8.139063,
                Longitude = -34.902598,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 446,
                Name = "Bueiro " + 446,
                Street = "Arraial, Estrada do",
                Latitude = -8.029410,
                Longitude = -34.908300,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 447,
                Name = "Bueiro " + 447,
                Street = "Uriel de Holanda, Rua",
                Latitude = -8.004139,
                Longitude = -34.899555,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 448,
                Name = "Bueiro " + 448,
                Street = "Souza Bandeira, Rua",
                Latitude = -8.048884,
                Longitude = -34.917864,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 449,
                Name = "Bueiro " + 449,
                Street = "Jean Emile Favre, Rua",
                Latitude = -8.107902,
                Longitude = -34.915933,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 450,
                Name = "Bueiro " + 450,
                Street = "Pampulha, Rua",
                Latitude = -8.109840,
                Longitude = -34.912939,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 451,
                Name = "Bueiro " + 451,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.013432,
                Longitude = -34.931481,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 452,
                Name = "Bueiro " + 452,
                Street = "Rui Barbosa, Av.",
                Latitude = -8.037930,
                Longitude = -34.905533,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 453,
                Name = "Bueiro " + 453,
                Street = "Apolo, Cais do",
                Latitude = -8.058771,
                Longitude = -34.872580,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 454,
                Name = "Bueiro " + 454,
                Street = "Apolo, Cais do",
                Latitude = -8.058860,
                Longitude = -34.872457,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 455,
                Name = "Bueiro " + 455,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.046379,
                Longitude = -34.876150,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 456,
                Name = "Bueiro " + 456,
                Street = "Norte Miguel Arraes de Alencar, Av.",
                Latitude = -8.031505,
                Longitude = -34.898032,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 457,
                Name = "Bueiro " + 457,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.050455,
                Longitude = -34.879040,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 458,
                Name = "Bueiro " + 458,
                Street = "Belém, Estrada de",
                Latitude = -8.032065,
                Longitude = -34.877881,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 459,
                Name = "Bueiro " + 459,
                Street = "Conselheiro Rosa e Silva, Av.",
                Latitude = -8.043634,
                Longitude = -34.897365,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 460,
                Name = "Bueiro " + 460,
                Street = "Parnamirim, Av.",
                Latitude = -8.035814,
                Longitude = -34.906837,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 461,
                Name = "Bueiro " + 461,
                Street = "Recife, Av.",
                Latitude = -8.088813,
                Longitude = -34.929836,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 462,
                Name = "Bueiro " + 462,
                Street = "Encanamento, Estrada do",
                Latitude = -8.032263,
                Longitude = -34.912967,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 464,
                Name = "Bueiro " + 464,
                Street = "Conselheiro Portela, Rua",
                Latitude = -8.042562,
                Longitude = -34.894676,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 465,
                Name = "Bueiro " + 465,
                Street = "Agamenon Magalhães, Av. Gov.",
                Latitude = -8.043816,
                Longitude = -34.887198,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 466,
                Name = "Bueiro " + 466,
                Street = "Príncipe, Rua do",
                Latitude = -8.057845,
                Longitude = -34.883644,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 467,
                Name = "Bueiro " + 467,
                Street = "Barão da Vitória, Rua",
                Latitude = -8.066941,
                Longitude = -34.883257,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 468,
                Name = "Bueiro " + 468,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.039662,
                Longitude = -34.871386,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 469,
                Name = "Bueiro " + 469,
                Street = "17 de Agosto, Av.",
                Latitude = -8.033854,
                Longitude = -34.922021,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 470,
                Name = "Bueiro " + 470,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.039706,
                Longitude = -34.871276,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 471,
                Name = "Bueiro " + 471,
                Street = "Mascarenhas de Morais, Av.",
                Latitude = -8.125187,
                Longitude = -34.914922,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 472,
                Name = "Bueiro " + 472,
                Street = "Moças, Rua das",
                Latitude = -8.021438,
                Longitude = -34.886511,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 473,
                Name = "Bueiro " + 473,
                Street = "12 de Setembro, Ponte",
                Latitude = -8.068208,
                Longitude = -34.874704,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 474,
                Name = "Bueiro " + 474,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.042124,
                Longitude = -34.873114,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 475,
                Name = "Bueiro " + 475,
                Street = "Dois Rios, Av.",
                Latitude = -8.115407,
                Longitude = -34.940297,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 476,
                Name = "Bueiro " + 476,
                Street = "Barão de Souza Leão, Rua",
                Latitude = -8.132819,
                Longitude = -34.911010,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 477,
                Name = "Bueiro " + 477,
                Street = "Madre de Deus, Rua",
                Latitude = -8.066185,
                Longitude = -34.873324,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 478,
                Name = "Bueiro " + 478,
                Street = "Cosme Viana, Rua",
                Latitude = -8.141132,
                Longitude = -34.911158,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 479,
                Name = "Bueiro " + 479,
                Street = "Cruz Cabugá, Av.",
                Latitude = -8.042155,
                Longitude = -34.873047,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 480,
                Name = "Bueiro " + 480,
                Street = "Beberibe, Av.",
                Latitude = -8.031910,
                Longitude = -34.89200,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 481,
                Name = "Bueiro " + 481,
                Street = "Sport Club do Recife, Rua",
                Latitude = -8.061132,
                Longitude = -34.904010,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 482,
                Name = "Bueiro " + 482,
                Street = "Do Forte, Av.",
                Latitude = -8.058380,
                Longitude = -34.931269,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 483,
                Name = "Bueiro " + 483,
                Street = "Boa Viagem, Av.",
                Latitude = -8.133277,
                Longitude = -34.900494,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 484,
                Name = "Bueiro " + 484,
                Street = "Domingos Ferreira, Av.",
                Latitude = -8.109199,
                Longitude = -34.891495,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 485,
                Name = "Bueiro " + 485,
                Street = "Leonardo Cavalcante, Rua",
                Latitude = -8.039059,
                Longitude = -34.911532,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 486,
                Name = "Bueiro " + 486,
                Street = "Conde da Boa Vista, Av.",
                Latitude = -8.061073,
                Longitude = -34.883421,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 487,
                Name = "Bueiro " + 487,
                Street = "José Bonifácio, Rua",
                Latitude = -8.041003,
                Longitude = -34.908696,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 488,
                Name = "Bueiro " + 488,
                Street = "República, Pça. da",
                Latitude = -8.060398,
                Longitude = -34.877658,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 489,
                Name = "Bueiro " + 489,
                Street = "Caxangá, Av.",
                Latitude = -8.054367,
                Longitude = -34.913983,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 490,
                Name = "Bueiro " + 490,
                Street = "Frei Matias Teves, Av.",
                Latitude = -8.066542,
                Longitude = -34.895424,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 491,
                Name = "Bueiro " + 491,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.086622,
                Longitude = -34.930909,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 492,
                Name = "Bueiro " + 492,
                Street = "Beberibe, Av.",
                Latitude = -8.025192,
                Longitude = -34.893494,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 493,
                Name = "Bueiro " + 493,
                Street = "Arquiteto Luis Nunes, Rua",
                Latitude = -8.088710,
                Longitude = -34.910400,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 494,
                Name = "Bueiro " + 494,
                Street = "Recife, Av.",
                Latitude = -8.096045,
                Longitude = -34.928796,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 495,
                Name = "Bueiro " + 495,
                Street = "Mem de Sá, Rua",
                Latitude = -8.029678,
                Longitude = -34.889778,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 496,
                Name = "Bueiro " + 496,
                Street = "Ribeiro de Brito, Rua",
                Latitude = -8.122962,
                Longitude = -34.905851,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 497,
                Name = "Bueiro " + 497,
                Street = "José Rufino, Av. Dr.",
                Latitude = -8.090773,
                Longitude = -34.956702,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 498,
                Name = "Bueiro " + 498,
                Street = "Joaquim Nabuco, Rua",
                Latitude = -8.052791,
                Longitude = -34.902218,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 499,
                Name = "Bueiro " + 499,
                Street = "Cosme Viana, Rua",
                Latitude = -8.065205,
                Longitude = -34.909143,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
            mocks.Add(new Manhole()
            {
                Id = 500,
                Name = "Bueiro " + 500,
                Street = "Dois Irmãos, Av.",
                Latitude = -8.021975,
                Longitude = -34.931659,
                Dimensions = new Dimension() { X = 100, Y = 100, Z = 500 },
                CurrentHeight = 4,
                GasState = EImportanceState.Normal,
                LastManteinance = DateTime.Now
            });
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
