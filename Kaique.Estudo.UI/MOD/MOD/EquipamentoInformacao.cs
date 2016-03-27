using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaique.Estudo.UI.MOD
{
   public class EquipamentoInformacao
   {
       #region 'ATRIBUTOS E ENCAPSULAMENTOS'
       private int _idEquipamento;
       private string _nomeEquipamento;
       private string _marcaEquipamento;
       private string _modeloEquipamento;
       private string _potenciaEquipamento;

       public int IdEquipamento
       {
           get { return _idEquipamento; }
           set { _idEquipamento = value; }
       }

       public string NomeEquipamento
       {
           get { return _nomeEquipamento; }
           set { _nomeEquipamento = value; }
       }

       public string MarcaEquipamento
       {
           get { return _marcaEquipamento; }
           set { _marcaEquipamento = value; }
       }

       public string ModeloEquipamento
       {
           get { return _modeloEquipamento; }
           set { _modeloEquipamento = value; }
       }

       public string PotenciaEquipamento
       {
           get { return _potenciaEquipamento; }
           set { _potenciaEquipamento = value; }
       }
       #endregion
   }
}
