# 🐦 YMH219 - Flappy Bird

**Nesne Tabanlı Programlama (YMH 219)** dersi kapsamında C# ve Windows Forms kullanılarak geliştirilen Flappy Bird benzeri masaüstü oyunudur.

## 📌 Proje Hakkında

Bu projede, klasik Flappy Bird oyunundan ilham alınarak basit bir masaüstü oyunu geliştirilmiştir.

Oyuncu, klavyedeki Space tuşunu kullanarak kuşu kontrol eder ve borulara çarpmadan engellerin arasından geçmeye çalışır.

Proje kapsamında nesne tabanlı programlama, klavye olayları, zamanlayıcı (Timer), hareket fiziği ve çarpışma kontrolü gibi temel programlama kavramları uygulanmıştır.

## ✨ Özellikler

- **Kuş Hareketi:** Space tuşu ile kuş yukarı doğru hareket eder.
- **Yer Çekimi:** Kuş, yer çekimi etkisiyle sürekli aşağı doğru hareket eder.
- **Engeller:** Borular ekranın sağ tarafından sol tarafına doğru hareket eder.
- **Çarpışma Kontrolü:** Kuşun borulara, tavana veya zemine çarpması durumunda oyun sona erer.
- **Skor Sistemi:** Başarıyla geçilen her engel için oyuncunun puanı artırılır.
- **Game Over Ekranı:** Çarpışma gerçekleştiğinde oyun sonu ekranı gösterilir.
- **Yeniden Başlatma:** Oyun bittikten sonra Space tuşu ile yeni oyun başlatılabilir.

## 🛠️ Kullanılan Teknolojiler

- C#
- .NET 10
- Windows Forms
- Visual Studio Community 2026
- System.Drawing
- Windows Forms Timer

## 🧱 Proje Yapısı

| Dosya | Açıklama |
|---|---|
| `Program.cs` | Uygulamanın başlangıç noktasıdır. |
| `Form1.cs` | Ana oyun mantığını, çizim işlemlerini, klavye olaylarını ve skor yönetimini içerir. |
| `Bird.cs` | Kuşun hareketini, yer çekimini, zıplama işlemini ve çizimini yönetir. |
| `Pipe.cs` | Engellerin hareketini, çizimini ve çarpışma kontrolünü yönetir. |

## 🎮 Oyun Kontrolleri

| Tuş | İşlev |
|---|---|
| `SPACE` | Oyunu başlatır. |
| `SPACE` | Kuşun yukarı zıplamasını sağlar. |
| `SPACE` | Game Over ekranından sonra oyunu yeniden başlatır. |

## 📸 Ekran Görüntüleri

### Oyun Ekranı (Gameplay)

![Gameplay Screenshot](screenshots/gameplay.png)

### Oyun Sonu Ekranı (Game Over)

![Game Over Screenshot](screenshots/game-over.png)


## ⚠️ Bilinen Sınırlamalar

- Uygulama Windows masaüstü ortamı için geliştirilmiştir.
- Grafikler Windows Forms ve System.Drawing kullanılarak programatik olarak oluşturulmuştur.
- Oyun şu anda tek oyunculu olarak çalışmaktadır.
- En yüksek skor kalıcı olarak kaydedilmemektedir.

- **Ders:** Nesne Tabanlı Programlama (YMH 219)
- **Proje:** Flappy Bird


## 📚 Projenin Eğitimsel Amacı

Bu proje, C# programlama dili kullanılarak nesne tabanlı programlama prensiplerinin, sınıf ve nesne yapılarının, olay yönetiminin, zamanlayıcı kullanımının, temel fizik işlemlerinin ve çarpışma kontrolünün uygulanmasını amaçlamaktadır.
