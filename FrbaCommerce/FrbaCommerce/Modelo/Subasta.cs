///////////////////////////////////////////////////////////
//  Subasta.cs
//  Implementation of the Class Subasta
//  Generated by Enterprise Architect
//  Created on:      25-May-2014 02:09:23 a.m.
//  Original author: sa
///////////////////////////////////////////////////////////




using Sistema;
using System.Collections.Generic;
namespace Sistema {
	public class Subasta : TipoPublicacion {

		private int valorInicial;
		private List<Oferta> ofertas;
		private int valorMaximo;
		private int calificacion;
		public Oferta m_Oferta;

		public Subasta(){

		}

		~Subasta(){

		}

		public virtual void Dispose(){

		}

	}//end Subasta

}//end namespace Sistema