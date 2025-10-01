namespace Basket.Data.JsonConverters;

public class ShoppingCartItemConverter : JsonConverter<ShoppingCartItem>
{

    public override ShoppingCartItem? Read(ref Utf8JsonReader reader,
                                       Type typeToConvert,
                                       JsonSerializerOptions options)
    {

        var jsonDocument = JsonDocument.ParseValue(ref reader);
        var rootElement = jsonDocument.RootElement;

        var id = rootElement.GetProperty("id").GetGuid();
        var color = rootElement.GetProperty("color").GetString()!;
        var price = rootElement.GetProperty("price").GetDecimal();
        var quantity = rootElement.GetProperty("quantity").GetInt32();
        var productId = rootElement.GetProperty("productId").GetGuid();
        var productName = rootElement.GetProperty("productName").GetString()!;
        var shoppingCartId = rootElement.GetProperty("shoppingCartId").GetGuid();

        return new ShoppingCartItem(id, shoppingCartId, productId, quantity, color, price, productName);
    }

    public override void Write(Utf8JsonWriter writer,
                               ShoppingCartItem value,
                               JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("color", value.Color);
        writer.WriteNumber("price", value.Price);
        writer.WriteString("id", value.Id.ToString());
        writer.WriteNumber("quantity", value.Quantity);
        writer.WriteString("productName", value.ProductName);
        writer.WriteString("productId", value.ProductId.ToString());
        writer.WriteString("shoppingCartId", value.ShoppingCartId.ToString());

        writer.WriteEndObject();
    }
}
