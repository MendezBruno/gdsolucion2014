///////////////////////////////////////////////////////////
//  StockComun.cs
//  Implementation of the Class StockComun
//  Generated by Enterprise Architect
//  Created on:      25-May-2014 02:09:22 a.m.
//  Original author: sa
///////////////////////////////////////////////////////////




using Sistema;
using System.Collections.Generic;
namespace Sistema {
	public class StockComun : TipoPublicacion {

		private List<Compra> compras= new List<Compra>();
		public Compra m_Compra;

		public StockComun(){

		}

		~StockComun(){

		}

		public virtual void Dispose(){

		}

		/// 
		/// <param name="stock"></param>
		public void agregarStock(int stock){

		}

	}//end StockComun

}//end namespace Sistema