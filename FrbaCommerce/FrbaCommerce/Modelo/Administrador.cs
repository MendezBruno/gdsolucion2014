///////////////////////////////////////////////////////////
//  Administrador.cs
//  Implementation of the Class Administrador
//  Generated by Enterprise Architect
//  Created on:      25-May-2014 02:08:58 a.m.
//  Original author: Bruno
///////////////////////////////////////////////////////////




using Sistema;
using System.Collections.Generic;
namespace Sistema {
	public class Administrador : TipoUsuario {

		public Administrador(){

		}

		~Administrador(){

		}

		public virtual void Dispose(){

		}

		/// 
		/// <param name="tDoc"></param>
		/// <param name="telefono"></param>
		/// <param name="nroPiso"></param>
		/// <param name="nombre"></param>
		/// <param name="Mail"></param>
		/// <param name="fecNac"></param>
		/// <param name="direccion"></param>
		/// <param name="depto"></param>
		/// <param name="codPostal"></param>
		/// <param name="apellido"></param>
		public Cliente crearCliente(string tDoc, long telefono, int nroPiso, string nombre, string Mail, string fecNac, string direccion, char depto, int codPostal, string apellido){

			return null;
		}

		/// 
		/// <param name="telefono"></param>
		/// <param name="razonSocial"></param>
		/// <param name="nroPiso"></param>
		/// <param name="nombreContacto"></param>
		/// <param name="mail"></param>
		/// <param name="localidad"></param>
		/// <param name="fecCreacion"></param>
		/// <param name="Direccion"></param>
		/// <param name="Depto"></param>
		/// <param name="Cuit"></param>
		/// <param name="codPos"></param>
		/// <param name="ciudad"></param>
		public Empresa crearEmpresa(long telefono, string razonSocial, int nroPiso, string nombreContacto, string mail, string localidad, string fecCreacion, string Direccion, char Depto, string Cuit, int codPos, string ciudad){

			return null;
		}

		public bool Alta(){

			return true;
		}

		public bool Baja(){

			return true;
		}

		public bool Modificacion(){

			return true;
		}

		/// 
		/// <param name="visibilidad"></param>
		/// <param name="compras"></param>
		/// <param name="subastas"></param>
		public Factura rendirFactura(VisibilidadPublicacion visibilidad, List<Compra> compras, List<Subasta> subastas){

			return null;
		}

	}//end Administrador

}//end namespace Sistema