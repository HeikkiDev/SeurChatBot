using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeurBot.Dialogs
{
    [LuisModel("c71f3f49-50c1-4061-a16b-fe78ea291c88", "00d670da99a6405b9cf4d9015e68328d", domain: "westus.api.cognitive.microsoft.com", log: false)]
    [Serializable]
    public class SeurDialog : LuisDialog<object>
    {
        /// <summary>
        /// Send a generic help message if an intent without an intent handler is detected.
        /// </summary>
        /// <param name="context">Dialog context.</param>
        /// <param name="result">The result from LUIS.</param>
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {

            string message = $"Lo siento, no te he entendido :( \n\n Detected intent: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intentSaludo")]
        public async Task Saludo(IDialogContext context, LuisResult result)
        {
            string smilingFace = "\U0001F642";
            
            await context.PostAsync("Hola!" + smilingFace);

            var message = context.MakeMessage();

            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://upload.wikimedia.org/wikipedia/commons/5/57/SEUR_logo.svg"));

            List<CardAction> cardButtons = new List<CardAction>();

            CardAction plButtonSeguimiento = new CardAction()
            {
                Value = $"https://es.wikipedia.org/wiki/Seur",
                Type = "openUrl",
                Title = "Seguimiento Pedido"
            };

            CardAction plButtonTiendas = new CardAction()
            {
                Value = $"https://es.wikipedia.org/wiki/Seur",
                Type = "openUrl",
                Title = "Búsqueda tiendas"
            };

            CardAction plButtonComoBuscar = new CardAction()
            {
                Value = $"https://es.wikipedia.org/wiki/Seur",
                Type = "openUrl",
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

            string message = $"Detected intent: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intentInfoEnvio")]
        public async Task InfoEnvio(IDialogContext context, LuisResult result)
        {

            string message = $"Detected intent: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("intentPreguntasFrecuentes")]
        public async Task PreguntasFrecuentes(IDialogContext context, LuisResult result)
        {

            string message = $"Detected intent: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

    }
}