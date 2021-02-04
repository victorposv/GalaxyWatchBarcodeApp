using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class CardService
    {
        private string _filePath;
        private IBarcodeService _barcodeService;

        public CardService(IBarcodeService barcodeService)
        {
            _filePath = string.Empty;
            _barcodeService = barcodeService;
        }
        public async Task<List<Card>> ReadCardsFromFileAsync()
        {
            string jsonString = await File.ReadAllTextAsync(_filePath);

            var result = JsonConvert.DeserializeObject<List<Card>>(jsonString);

            return result;
        }

        public async Task SaveCardToFileAsync(Card card)
        {
            if (File.Exists(_filePath))
            {
                var existingCards = await ReadCardsFromFileAsync();
                existingCards.Add(card);
                await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(existingCards));
            }
            else
            {
                File.Create(_filePath);
                await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(card));
            }
        }

        public Card CreateCard(string name, string description, string imagePath)
        {
            Barcode barcode = _barcodeService.ReadBarcode(imagePath);

            if (barcode == null)
                return null;
            else
                return new Card { Name = name, Barcode = barcode, Description = description };
        }
    }
}
