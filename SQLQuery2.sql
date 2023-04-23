delete from Hotel join Adress on Hotel.IdAdress = Adress.Id join City on City.Id = Adress.Id and City.Description = 'São Carlos' and Hotel.Name = 'Hotel Sanca';

select *  from Adress join City on Adress.IdCity = City.Id

select * from City where Id = 1023


select * from Adress

select *  from Hotel

delete from Adress
delete from Client where Id = 1009

select * from Client
select * from Adress

delete from Hotel join Adress on Hotel.IdAdress = Adress.Id join City on City.Id = Adress.Id and City.Description = 'São Carlos' and Hotel.Name = 'Hotel Sanca';


delete from Hotel where Hotel.Name = 'Hotel SANCA' and  Hotel.IdAdress in (
select Adress.Id from Adress join City on Adress.IdCity = City.Id and City.Description ='São Carlos');

select * from ticket

delete from Ticket where Id = 2