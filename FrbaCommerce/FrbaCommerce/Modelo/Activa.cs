///////////////////////////////////////////////////////////
//  Activa.cs
//  Implementation of the Class Activa
//  Generated by Enterprise Architect
//  Created on:      25-May-2014 02:08:57 a.m.
//  Original author: sa
///////////////////////////////////////////////////////////




using Sistema;
namespace Sistema {
	public class Activa : EstadoPublicacion {

		public Activa(){

		}

		~Activa(){

		}

		public virtual void Dispose(){

		}

        public void cambiarEstado()
        {

        }

		/// 
		/// <param name="tipoPublicacion"></param>
		public int AgregarStock(TipoPublicacion tipoPublicacion){

			return 0;
		}

        /*
		public EstadoPublicacion cambiarEstado(){

			return null;
		}
        */
		/// 
		/// <param name="descripcion"></param>
		public void cambiarDescripcion(string descripcion){

		}

	}//end Activa

}//end namespace Sistema