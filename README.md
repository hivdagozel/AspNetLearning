# AspNetLearning

ASP.NET Core, Entity Framework Core, SQL Server, Repository Pattern, AutoMapper, xUnit ve Moq öğrenmek amacıyla geliştirilmiş ürün yönetimi Web API projesidir.

## Özellikler

- Ürün listeleme, görüntüleme, ekleme, güncelleme ve silme
- Entity Framework Core ile SQL Server LocalDB bağlantısı
- Repository ve Service katmanları
- DTO ve AutoMapper kullanımı
- xUnit ve Moq ile unit testler
- Repository ve mapper bağımlılıklarının mocklanması

## Kullanılan Teknolojiler

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- AutoMapper
- xUnit
- Moq

## Proje Yapısı

```text
AspNetLearning.Api
├── Controllers
├── Data
├── Dtos
├── Mappings
├── Models
├── Repositories
├── Services
└── Migrations

AspNetLearning.Tests
├── ProductServiceTests.cs
└── ProductsControllerTests.cs
```

## Kurulum

1. Repoyu klonlayın.
2. Visual Studio ile `AspNetLearning.slnx` dosyasını açın.
3. `AspNetLearning.Api` projesini başlangıç projesi olarak ayarlayın.
4. Paket Yöneticisi Konsolu'nda varsayılan proje olarak `AspNetLearning.Api` seçin.
5. Veritabanını oluşturmak için aşağıdaki komutu çalıştırın:

```powershell
Update-Database
```

6. Projeyi `Ctrl+F5` ile çalıştırın.

Varsayılan geliştirme adresleri:

```text
https://localhost:7112
http://localhost:5135
```

## API Uçları

| Metot | Adres | Açıklama |
|---|---|---|
| GET | `/api/products` | Tüm ürünleri getirir |
| GET | `/api/products/{id}` | Bir ürünü getirir |
| POST | `/api/products` | Yeni ürün ekler |
| PUT | `/api/products/{id}` | Ürünü günceller |
| DELETE | `/api/products/{id}` | Ürünü siler |

Örnek istekler `AspNetLearning.Api/AspNetLearning.Api.http` dosyasında bulunur.

## Testler

Visual Studio Test Gezgini üzerinden veya aşağıdaki komutla çalıştırılabilir:

```powershell
dotnet test
```

Unit testlerde gerçek SQL Server ve gerçek AutoMapper yerine Moq ile oluşturulan kontrollü sahte bağımlılıklar kullanılır.
