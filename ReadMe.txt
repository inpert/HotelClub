You must point the database path in App.Config in every integration test to make it work:

For example:

<add name="HotelClubDatabase" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=HotelClub;Integrated Security=SSPI;AttachDBFilename=E:\OfficialProjects\hotel\HotelMensal\HotelClub.Web\App_Data\HotelClub.mdf" providerName="System.Data.SqlClient" />

Change the "E:\OfficialProjects\hotel\HotelMensal\HotelClub.Web\App_Data\HotelClub.mdf" to your proper path.