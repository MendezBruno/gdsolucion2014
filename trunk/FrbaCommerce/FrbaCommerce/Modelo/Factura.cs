///////////////////////////////////////////////////////////
//  Factura.cs
//  Implementation of the Class Factura
//  Generated by Enterprise Architect
//  Created on:      25-May-2014 02:09:10 a.m.
//  Original author: sa
///////////////////////////////////////////////////////////




using Sistema;
using System.Collections.Generic;
namespace Sistema {
	public class Factura {

		private List<Item> items;
		private string fecha;
		private string formaDePago;
		private float total;
		public Item m_Item;

		public Factura(){

		}

		~Factura(){

		}

		public virtual void Dispose(){

		}

		/// 
		/// <param name="visibilidad"></param>
		/// <param name="subastas"></param>
		public Item generarItemSubasta(VisibilidadPublicacion visibilidad, List<Subasta> subastas){

			return null;
		}

		/// 
		/// <param name="visibilidad"></param>
		/// <param name="compras"></param>
		public Item generarItemCompra(VisibilidadPublicacion visibilidad, List<Compra> compras){

			return null;
		}

	}//end Factura

}//end namespace Sistema