using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace SeurBot.Dialogs
{
    [LuisModel("c71f3f49-50c1-4061-a16b-fe78ea291c88", "00d670da99a6405b9cf4d9015e68328d", domain: "westus.api.cognitive.microsoft.com", log: false)]
    [Serializable]
    public class SeurDialog : LuisDialog<object>
    {
        private static string smilingFace = "\U0001F642";

        /// <summary>
        /// Send a generic help message if an intent without an intent handler is detected.
        /// </summary>
        /// <param name="context">Dialog context.</param>
        /// <param name="result">The result from LUIS.</param>
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            //string message = $"Detected intent: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            string message = $"Lo siento, no te he entendido :(";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intentSaludo")]
        public async Task Saludo(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hola!" + smilingFace);

            var message = context.MakeMessage();

            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://upload.wikimedia.org/wikipedia/commons/5/57/SEUR_logo.svg"));

            List<CardAction> cardButtons = new List<CardAction>();

            CardAction plButtonSeguimiento = new CardAction()
            {
                Value = $"Seguimiento pedido",
                Type = "imBack",
                Title = "Seguimiento pedido"
            };

            CardAction plButtonTiendas = new CardAction()
            {
                Value = $"Búsqueda tiendas",
                Type = "imBack",
                Title = "Búsqueda tiendas"
            };

            CardAction plButtonComoBuscar = new CardAction()
            {
                Value = $"Cómo buscar",
                Type = "imBack",
                Title = "Cómo buscar"
            };

            cardButtons.Add(plButtonSeguimiento);
            cardButtons.Add(plButtonTiendas);
            cardButtons.Add(plButtonComoBuscar);

            HeroCard heroCard = new HeroCard()
            {
                Title = $"Encantado de conocerte, " + message.Recipient.Name + "!",
                Subtitle = $"Escribe 'hola' en cualquier momento para guiarte",
                Images = cardImages,
                Buttons = cardButtons
            };

            message.Attachments = new List<Attachment>();
            message.Attachments.Add(heroCard.ToAttachment());

            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intentGracias")]
        public async Task Gracias(IDialogContext context, LuisResult result)
        {
            string message = "De nada!";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intentInfoEnvio")]
        public async Task InfoEnvio(IDialogContext context, LuisResult result)
        {
            // Call to SOAP Web Services. How to use the SOAP Interface --> https://msdn.microsoft.com/en-us/library/ff512390.aspx

            // Read the simulate data response from web services
            string callResult = Properties.Resources.RespuestaModeloEnvioSeur;

            // Deserialize XML response to Model
            XmlSerializer serializer = new XmlSerializer(typeof(SeurBot.Models.ENVIOS));
            SeurBot.Models.ENVIOS envioInfo = null;
            try
            {
                using (TextReader reader = new StringReader(callResult))
                {
                    envioInfo = (SeurBot.Models.ENVIOS)serializer.Deserialize(reader);
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            // Make "envios" status cards
            string numExpedicion = envioInfo.EXPEDICION.EXPEDICION_NUM.ToString();
            string origen = envioInfo.EXPEDICION.REMITE_POBLACION.ToString();
            string destino = envioInfo.EXPEDICION.DESTINA_POBLACION.ToString();
            await context.PostAsync("Has solicitado información sobre eñ siguiente envío: \n - Númer de expedición: " + numExpedicion + "\n - Origen: " + origen + "\n - Destino: " + destino);

            var message = context.MakeMessage();
            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            message.Attachments = new List<Attachment>();

            foreach (var situacion in envioInfo.EXPEDICION.SITUACIONES.SITUACION)
            {
                List<CardImage> cardImages = new List<CardImage>();
                cardImages.Add(new CardImage(url: "http://nemanjakovacevic.net/wp-content/uploads/2013/07/placeholder.png"));

                HeroCard heroCard = new HeroCard()
                {
                    Title = situacion.GRUPO.ToString(),
                    Subtitle = situacion.FECHA.ToString(),
                    Images = cardImages
                };

                message.Attachments.Add(heroCard.ToAttachment());
            }

            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intentPreguntasFrecuentes")]
        public async Task PreguntasFrecuentes(IDialogContext context, LuisResult result)
        {
            string message = $"Lo siento, esta función está en desarrollo " + smilingFace + " Detected intent: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intentBusquedaTiendas")]
        public async Task BusquedaTiendas(IDialogContext context, LuisResult result)
        {
            string message = $"Lo siento, esta función está en desarrollo " + smilingFace + " Detected intent: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intentComoBuscar")]
        public async Task ComoBuscar(IDialogContext context, LuisResult result)
        {
            string message = $"Lo siento, esta función está en desarrollo " + smilingFace + " Detected intent: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}