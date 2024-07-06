using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Encryption;

public class RequestHandeler {
    public static IResult Encrypt(HttpRequest request) {
        try {
            string text = request.Form["text"].ToString();
            bool isAscci = request.Form["isAscci"].ToString().Equals("true", StringComparison.CurrentCultureIgnoreCase);
            
            string content = JsonSerializer.Serialize(new Dictionary<string, string> () {
                    {"status", "Ok"},
                    {"encryptedText", HashTable.GetEncryptedText(text, isAscci)}
                });

            return Results.Ok(content);

            // return ["Ok", HashTable.GetEncryptedText(text, isAscci)];
        } catch (Exception e) {
            string content = JsonSerializer.Serialize(new Dictionary<string, string> () {
                    {"status", "Bad Request"},
                    {"encryptedText", e.Message}
            });
            Console.WriteLine(e);

            return Results.BadRequest(content);
        }
    }

    public static IResult Decrypt(HttpRequest request) {
        try {
            string text = request.Form["text"].ToString();
            bool isAscci = request.Form["isAscci"].ToString().Equals("true", StringComparison.CurrentCultureIgnoreCase);
            
            string content = JsonSerializer.Serialize(new Dictionary<string, string> () {
                    {"status", "Ok"},
                    {"encryptedText", HashTable.GetDecryptedText(text, isAscci)}
                });

            return Results.Ok(content);
        } catch (Exception e) {
            string content = JsonSerializer.Serialize(new Dictionary<string, string> () {
                    {"status", "Bad Request"},
                    {"encryptedText", e.Message}
            });
            Console.WriteLine(e);
            return Results.BadRequest(content);
        }
    }
}