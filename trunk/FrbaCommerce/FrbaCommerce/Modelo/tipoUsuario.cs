///////////////////////////////////////////////////////////
//  TipoUsuario.cs
//  Implementation of the Interface TipoUsuario
//  Generated by Enterprise Architect
//  Created on:      25-May-2014 02:09:25 a.m.
//  Original author: Bruno
///////////////////////////////////////////////////////////




using Sistema;
using System.Collections.Generic;
namespace Sistema {
	public interface TipoUsuario {

		bool Alta();

		bool Baja();

		bool Modificacion();

		/// 
		/// <param name="visibilidad"></param>
		/// <param name="compras"></param>
		/// <param name="subastas"></param>
		Factura rendirFactura(VisibilidadPublicacion visibilidad, List<Compra> compras, List<Subasta> subastas);
	}//end TipoUsuario

}//end namespace Sistema