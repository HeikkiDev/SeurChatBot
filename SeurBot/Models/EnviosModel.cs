using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SeurBot.Models
{
    [XmlRoot(ElementName = "SITUACION")]
    public class SITUACION
    {
        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }
        [XmlElement(ElementName = "FECHA")]
        public string FECHA { get; set; }
        [XmlElement(ElementName = "GRUPO")]
        public string GRUPO { get; set; }
    }

    [XmlRoot(ElementName = "SITUACIONES")]
    public class SITUACIONES
    {
        [XmlElement(ElementName = "SITUACION")]
        public List<SITUACION> SITUACION { get; set; }
    }

    [XmlRoot(ElementName = "EXPEDICION")]
    public class EXPEDICION
    {
        [XmlElement(ElementName = "REF_AGENTE_BULTO")]
        public string REF_AGENTE_BULTO { get; set; }
        [XmlElement(ElementName = "REF_AGENTE")]
        public string REF_AGENTE { get; set; }
        [XmlElement(ElementName = "PESO")]
        public string PESO { get; set; }
        [XmlElement(ElementName = "SERVICIO_PRODUCTO")]
        public string SERVICIO_PRODUCTO { get; set; }
        [XmlElement(ElementName = "CCN")]
        public string CCN { get; set; }
        [XmlElement(ElementName = "FECHA_CAPTURA")]
        public string FECHA_CAPTURA { get; set; }
        [XmlElement(ElementName = "REMITE_POBLACION")]
        public string REMITE_POBLACION { get; set; }
        [XmlElement(ElementName = "INTENTO_PREVIO_ENTREGA")]
        public string INTENTO_PREVIO_ENTREGA { get; set; }
        [XmlElement(ElementName = "F_REAL_ENTREGA")]
        public string F_REAL_ENTREGA { get; set; }
        [XmlElement(ElementName = "ENTREGA_IDENTIFICADOR")]
        public string ENTREGA_IDENTIFICADOR { get; set; }
        [XmlElement(ElementName = "SITUACION_AUSENTES")]
        public string SITUACION_AUSENTES { get; set; }
        [XmlElement(ElementName = "DESTINA_POBLACION")]
        public string DESTINA_POBLACION { get; set; }
        [XmlElement(ElementName = "FECHA_SIT_AUSENTES")]
        public string FECHA_SIT_AUSENTES { get; set; }
        [XmlElement(ElementName = "BULTOS")]
        public string BULTOS { get; set; }
        [XmlElement(ElementName = "FECHA_PREV_ENTREGA")]
        public string FECHA_PREV_ENTREGA { get; set; }
        [XmlElement(ElementName = "REMITE_REF")]
        public string REMITE_REF { get; set; }
        [XmlElement(ElementName = "REF_CLIENTE_BULTO")]
        public string REF_CLIENTE_BULTO { get; set; }
        [XmlElement(ElementName = "REMITE_NIF")]
        public string REMITE_NIF { get; set; }
        [XmlElement(ElementName = "PREVIO_NUM")]
        public string PREVIO_NUM { get; set; }
        [XmlElement(ElementName = "EXPEDICION_NUM")]
        public string EXPEDICION_NUM { get; set; }
        [XmlElement(ElementName = "FECHA_ESTIMADA")]
        public string FECHA_ESTIMADA { get; set; }
        [XmlElement(ElementName = "VALOR_TEL")]
        public string VALOR_TEL { get; set; }
        [XmlElement(ElementName = "SITUACIONES")]
        public SITUACIONES SITUACIONES { get; set; }
        [XmlElement(ElementName = "CENTRO_SEUR")]
        public string CENTRO_SEUR { get; set; }
        [XmlElement(ElementName = "CENTRO_PUDO")]
        public string CENTRO_PUDO { get; set; }
        [XmlElement(ElementName = "PERMITE_CAMBIA_FECHA")]
        public string PERMITE_CAMBIA_FECHA { get; set; }
        [XmlElement(ElementName = "LONGITUD")]
        public string LONGITUD { get; set; }
        [XmlElement(ElementName = "LATITUD")]
        public string LATITUD { get; set; }
        [XmlElement(ElementName = "TELEFONO_DESTINATARIO")]
        public string TELEFONO_DESTINATARIO { get; set; }
        [XmlElement(ElementName = "COD_POSTAL_DESTINATARIO")]
        public string COD_POSTAL_DESTINATARIO { get; set; }
        [XmlElement(ElementName = "COD_SITUACION")]
        public string COD_SITUACION { get; set; }
        [XmlElement(ElementName = "EMAIL_DESTINATARIO")]
        public string EMAIL_DESTINATARIO { get; set; }
        [XmlElement(ElementName = "NUM_POBLACION_DEST")]
        public string NUM_POBLACION_DEST { get; set; }
    }

    [XmlRoot(ElementName = "ENVIOS")]
    public class ENVIOS
    {
        [XmlElement(ElementName = "EXPEDICION")]
        public EXPEDICION EXPEDICION { get; set; }
        [XmlAttribute(AttributeName = "NUM")]
        public string NUM { get; set; }
    }
}