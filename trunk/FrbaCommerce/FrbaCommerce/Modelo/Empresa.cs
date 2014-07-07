///////////////////////////////////////////////////////////
//  Empresa.cs
//  Implementation of the Class Empresa
//  Generated by Enterprise Architect
//  Created on:      25-May-2014 02:09:08 a.m.
//  Original author: Bruno
///////////////////////////////////////////////////////////




using Sistema;
using System.Collections.Generic;
using System;
namespace Sistema {
	public class Empresa : Usuario {


        public string idEmpresa { get; set; }
        public string Razonsocial { get; set; }
        public string Mail { get; set; }
        public long Telefono { get; set; }
        public string Direccion { get; set; }
        public int numeroCalle { get; set; }
        public int NroPiso { get; set; }
        public char Depto { get; set; }
        public string localidad { get; set; }
        public int codigoPostal { get; set; }
        public string ciudad { get; set; }
        public string CUIT { get; set; }
        public string nombreDeContacto { get; set; }
        public DateTime fechaDeCreacion { get; set; }
		public Publicacion m_Publicacion;
        public bool puedeComprar { get; set; }

		public Empresa(){

		}

		~Empresa(){

		}

		

		/// 
		/// <param name="tipoPublicacion"></param>
		/// <param name="visibilidadPublicacion"></param>
		/// <param name="aceptaPregunta"></param>
		/// <param name="rubro"></param>
		/// <param name="precio"></param>
		/// <param name="stock"></param>
		/// <param name="descripcion"></param>
		public Publicacion generarPublicacion(TipoPublicacion tipoPublicacion, VisibilidadPublicacion visibilidadPublicacion, bool aceptaPregunta, Rubro rubro, float precio, int stock, string descripcion){

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

	}//end Empresa

}//end namespace Sistema