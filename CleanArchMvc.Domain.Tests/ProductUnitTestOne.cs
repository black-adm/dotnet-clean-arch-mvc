using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTestOne
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                "product-image.jpg"
            );

            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Exception When Creating Product With Invalid Id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(
                -1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                "product-image.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Exception When Creating Product With Short Name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(
                1,
                "Ab",
                "Product Description",
                9.99m,
                99,
                "product-image.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Exception When Creating Product With Missing Name Value")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(
                1,
                "",
                "Product Description",
                9.99m,
                99,
                "product-image.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Name cannot be null or empty.");
        }

        [Fact(DisplayName = "Exception When Creating Product With Invalid Name Value")]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(
                1,
                null,
                "Product Description",
                9.99m,
                99,
                "product-image.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Name cannot be null or empty.");
        }

        [Fact(DisplayName = "Exception When Creating Product With Short Description")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Desc",
                9.99m,
                99,
                "product-image.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "Exception When Creating Product With Missing Description Value")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "",
                9.99m,
                99,
                "product-image.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Description cannot be null or empty.");
        }

        [Fact(DisplayName = "Exception When Creating Product With Invalid Description Value")]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                null,
                9.99m,
                99,
                "product-image.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Description cannot be null or empty.");
        }

        [Fact(DisplayName = "Exception When Creating Product With Negative Price")]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                -1.99m,
                99,
                "product-image.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price product value.");
        }

        [Fact(DisplayName = "Exception When Creating Product With Negative Stock")]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                -1,
                "product-image.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }

        [Fact(DisplayName = "Exception When Creating Product With Long Image Url")]
        public void CreateProduct_LongImageUrl_DomainExceptionLongImage()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                "this-is-a-very-long-image-url-that-exceeds-the-maximum-allowed-length-of-250-characters-this-is-a-very-long-image-url-that-exceeds-the-maximum-allowed-length-of-250-characters-this-is-a-very-long-image-url-that-exceeds-the-maximum-allowed-length-of-250-characters.jpg"
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image url, too long, maximum 250 characters.");
        }

        [Fact(DisplayName = "Create Product With Null Image Url")]
        public void CreateProduct_WithNullImageUrl_ResultObjectValidState()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                null
            );

            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Empty Image Url")]
        public void CreateProduct_WithEmptyImageUrl_ResultObjectValidState()
        {
            Action action = () => new Product(
                1,
                "Product Name",
                "Product Description",
                9.99m,
                99,
                ""
            );

            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Update Product With Valid Parameters")]
        public void UpdateProduct_WithValidParameters_ResultObjectValidState()
        {
            var product = new Product(
                1,
                "Original Name",
                "Original Description",
                10.00m,
                100,
                "original-image.jpg"
            );

            Action action = () => product.Update(
                "Updated Name",
                "Updated Description",
                20.00m,
                200,
                "updated-image.jpg",
                2
            );

            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Exception When Updating Product With Invalid Parameters")]
        public void UpdateProduct_WithInvalidParameters_DomainExceptionValidation()
        {
            var product = new Product(
                1,
                "Original Name",
                "Original Description",
                10.00m,
                100,
                "original-image.jpg"
            );

            Action action = () => product.Update(
                "Up",
                "Desc",
                -10.00m,
                -100,
                new string('a', 251),
                2
            );

            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }
    }
}