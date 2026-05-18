CREATE PROCEDURE sp_DeductStockOnOrder
    @OrderId INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE p
        SET p.StockQuantity = p.StockQuantity - oi.Quantity
        FROM Products p
        INNER JOIN OrderItems oi ON p.ProductId = oi.ProductId
        WHERE oi.OrderId = @OrderId;

        IF EXISTS (
            SELECT 1 
            FROM Products p
            INNER JOIN OrderItems oi ON p.ProductId = oi.ProductId
            WHERE oi.OrderId = @OrderId AND p.StockQuantity < 0
        )
        BEGIN
            THROW 50000, 'Недостаточно товара на складе', 1;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;