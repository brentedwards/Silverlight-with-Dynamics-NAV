﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;

namespace NAV.Models.Repositories.Mock
{
	public sealed class MockCustomerRepository : CustomerRepository, ICustomerRepository, IRepository
	{
		public void LoadCustomersAsync(string authToken, Action<System.Collections.Generic.IEnumerable<Customer>, Exception> callback)
		{
			var worker = new BackgroundWorker();
			worker.DoWork += (sender, e) =>
			{
				System.Threading.Thread.Sleep(2000);
			};
			worker.RunWorkerCompleted += (sender, e) =>
			{
				var stream = new StringReader(XML);
				var doc = XDocument.Load(stream);

				try
				{
					var customers = ParseXml(doc);
					callback(customers, null);
				}
				catch (Exception ex)
				{
					callback(null, ex);
				}
			};
			worker.RunWorkerAsync();
		}

		public void SaveCustomer(Customer customer, Action<bool, Exception> callback)
		{
			var worker = new BackgroundWorker();
			worker.DoWork += (sender, e) =>
			{
				System.Threading.Thread.Sleep(2000);
			};
			worker.RunWorkerCompleted += (sender, e) =>
			{
				callback(true, null);
			};
			worker.RunWorkerAsync();
		}

		private const string XML = "<?xml version='1.0' encoding='utf-8'?><GetCustomerList version='1.0' xmlns='http://silverlight.digitalmajik.com/GetCustomerList'><Customers Records='80'><Customer><Field_1 FieldCaption='No.'>01121212</Field_1><Field_2 FieldCaption='Name'>Spotsmeyer's Furnishings</Field_2><Field_5 FieldCaption='Address'>612 South Sunset Drive</Field_5><Field_7 FieldCaption='City'>Miami</Field_7><Field_92 FieldCaption='State'>FL</Field_92><Field_91 FieldCaption='ZIP Code'>37125</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>spotsmeyer's.furnishings@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>01445544</Field_1><Field_2 FieldCaption='Name'>Progressive Home Furnishings</Field_2><Field_5 FieldCaption='Address'>3000 Roosevelt Blvd.</Field_5><Field_7 FieldCaption='City'>Chicago</Field_7><Field_92 FieldCaption='State'>IL</Field_92><Field_91 FieldCaption='ZIP Code'>61236</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>progressive.home.furnishings@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>01454545</Field_1><Field_2 FieldCaption='Name'>New Concepts Furniture</Field_2><Field_5 FieldCaption='Address'>705 West Peachtree Street</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>31772</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>new.concepts.furniture@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>01905893</Field_1><Field_2 FieldCaption='Name'>Candoxy Canada Inc.</Field_2><Field_5 FieldCaption='Address'>18 Cumberland Street</Field_5><Field_7 FieldCaption='City'>Thunder Bay</Field_7><Field_92 FieldCaption='State'>ON</Field_92><Field_91 FieldCaption='ZIP Code'>P7B 5E2</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>candoxy.canada.inc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>01905899</Field_1><Field_2 FieldCaption='Name'>Elkhorn Airport</Field_2><Field_5 FieldCaption='Address'>105 Buffalo Dr.</Field_5><Field_7 FieldCaption='City'>Elkhorn</Field_7><Field_92 FieldCaption='State'>MB</Field_92><Field_91 FieldCaption='ZIP Code'>R0M 0N0</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>elkhorn.airport@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>01905902</Field_1><Field_2 FieldCaption='Name'>London Candoxy Storage Campus</Field_2><Field_5 FieldCaption='Address'>120 Wellington Rd.</Field_5><Field_7 FieldCaption='City'>London</Field_7><Field_92 FieldCaption='State'>ON</Field_92><Field_91 FieldCaption='ZIP Code'>N6B 1V7</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>london.candoxy.storage.campus@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>10000</Field_1><Field_2 FieldCaption='Name'>The Cannon Group PLC</Field_2><Field_5 FieldCaption='Address'>192 Market Square</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>31772</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>20000</Field_1><Field_2 FieldCaption='Name'>Selangorian Ltd.</Field_2><Field_5 FieldCaption='Address'>153 Thomas Drive</Field_5><Field_7 FieldCaption='City'>Chicago</Field_7><Field_92 FieldCaption='State'>IL</Field_92><Field_91 FieldCaption='ZIP Code'>61236</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>selangorian.ltd@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>20309920</Field_1><Field_2 FieldCaption='Name'>Metatorad Malaysia Sdn Bhd</Field_2><Field_5 FieldCaption='Address'>No 16M Jalan SS22</Field_5><Field_7 FieldCaption='City'>PETALING JAYA, Selangor</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>MY-47400</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>metatorad.malaysia.sdn.bhd@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>20312912</Field_1><Field_2 FieldCaption='Name'>Highlights Electronics Sdn Bhd</Field_2><Field_5 FieldCaption='Address'>28 Ground Floor, 1 Jalan 3/26</Field_5><Field_7 FieldCaption='City'>KUALA LUMPUR</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>MY-57000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>highlights.electronics.sdn.bhd@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>20339921</Field_1><Field_2 FieldCaption='Name'>TraxTonic Sdn Bhd</Field_2><Field_5 FieldCaption='Address'>Sama Jaya Free Industrial Zone</Field_5><Field_7 FieldCaption='City'>KUCHING, Sarawak</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>MY-93450</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>traxtonic.sdn.bhd@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>21233572</Field_1><Field_2 FieldCaption='Name'>Somadis</Field_2><Field_5 FieldCaption='Address'>37, Rue El Wahda</Field_5><Field_7 FieldCaption='City'>AGDAL-RABAT</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>MO-10100</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>somadis@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>21245278</Field_1><Field_2 FieldCaption='Name'>Maronegoce</Field_2><Field_5 FieldCaption='Address'>21, Boulevard de la Nation</Field_5><Field_7 FieldCaption='City'>CASABLANCA</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>MO-20200</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>maronegoce@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>21252947</Field_1><Field_2 FieldCaption='Name'>ElectroMAROC</Field_2><Field_5 FieldCaption='Address'>11, Avenue des FAR</Field_5><Field_7 FieldCaption='City'>TEMARA</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>MO-12000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>electromaroc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>27090917</Field_1><Field_2 FieldCaption='Name'>Zanlan Corp.</Field_2><Field_5 FieldCaption='Address'>2 Beta Street</Field_5><Field_7 FieldCaption='City'>Carletonville</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>ZA-2500</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>zanlan.corp@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>27321782</Field_1><Field_2 FieldCaption='Name'>Karoo Supermarkets</Field_2><Field_5 FieldCaption='Address'>38 Voortrekker Street</Field_5><Field_7 FieldCaption='City'>Bloemfontein</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>ZA-9300</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>karoo.supermarkets@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>27489991</Field_1><Field_2 FieldCaption='Name'>Durbandit Fruit Exporters</Field_2><Field_5 FieldCaption='Address'>100 St. George's Mall</Field_5><Field_7 FieldCaption='City'>Durban</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>ZA-3600</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>durbandit.fruit.exporters@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>30000</Field_1><Field_2 FieldCaption='Name'>John Haddock Insurance Co.</Field_2><Field_5 FieldCaption='Address'>10 High Tower Green</Field_5><Field_7 FieldCaption='City'>Miami</Field_7><Field_92 FieldCaption='State'>FL</Field_92><Field_91 FieldCaption='ZIP Code'>37125</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>john.haddock.insurance.co@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>31505050</Field_1><Field_2 FieldCaption='Name'>Woonboulevard Kuitenbrouwer</Field_2><Field_5 FieldCaption='Address'>Industrieweg 11</Field_5><Field_7 FieldCaption='City'>Zutphen</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>NL-7202 BP</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>woonboulevard.kuitenbrouwer@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>31669966</Field_1><Field_2 FieldCaption='Name'>Meersen Meubelen</Field_2><Field_5 FieldCaption='Address'>Vijfpoortenweg 71</Field_5><Field_7 FieldCaption='City'>Arnhem</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>NL-6827 BP</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>meersen.meubelen@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>31987987</Field_1><Field_2 FieldCaption='Name'>Candoxy Nederland BV</Field_2><Field_5 FieldCaption='Address'>Westzijdewal 123</Field_5><Field_7 FieldCaption='City'>Amsterdam</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>NL-1009 AG</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>candoxy.nederland.bv@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>32124578</Field_1><Field_2 FieldCaption='Name'>Nieuwe Zandpoort NV</Field_2><Field_5 FieldCaption='Address'>Nieuwstraat 28</Field_5><Field_7 FieldCaption='City'>Herentals</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>BE-2200</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>nieuwe.zandpoort.nv@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>32656565</Field_1><Field_2 FieldCaption='Name'>Antarcticopy</Field_2><Field_5 FieldCaption='Address'>Katwilgweg 274</Field_5><Field_7 FieldCaption='City'>Antwerpen</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>BE-2050</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>antarcticopy@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>32789456</Field_1><Field_2 FieldCaption='Name'>Lovaina Contractors</Field_2><Field_5 FieldCaption='Address'>Vuurberg 137</Field_5><Field_7 FieldCaption='City'>Leuven</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>BE-3000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>lovaina.contractors@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>33000019</Field_1><Field_2 FieldCaption='Name'>Francematic</Field_2><Field_5 FieldCaption='Address'>19 Boulevard Commanderie</Field_5><Field_7 FieldCaption='City'>PLAISIR</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>FR-78370</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>francematic@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>33002984</Field_1><Field_2 FieldCaption='Name'>Parmentier Boutique</Field_2><Field_5 FieldCaption='Address'>34 Avenue Parmentier</Field_5><Field_7 FieldCaption='City'>PARIS</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>FR-75000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>parmentier.boutique@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>33022842</Field_1><Field_2 FieldCaption='Name'>Livre Importants</Field_2><Field_5 FieldCaption='Address'>46 Rue Orteaux</Field_5><Field_7 FieldCaption='City'>ESBLY</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>FR-77450</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>livre.importants@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>34010100</Field_1><Field_2 FieldCaption='Name'>Libros S.A.</Field_2><Field_5 FieldCaption='Address'>Plaza Redonda 12</Field_5><Field_7 FieldCaption='City'>Barcelona</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>ES-08010</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>libros.sa@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>34010199</Field_1><Field_2 FieldCaption='Name'>Corporación Beta</Field_2><Field_5 FieldCaption='Address'>Avda. Europa 2</Field_5><Field_7 FieldCaption='City'>Valencia</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>ES-46007</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>corporacion.beta@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>34010602</Field_1><Field_2 FieldCaption='Name'>Helguera industrial</Field_2><Field_5 FieldCaption='Address'>c/ Paz 5</Field_5><Field_7 FieldCaption='City'>Madrid</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>ES-28003</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>helguera.industrial@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>35122112</Field_1><Field_2 FieldCaption='Name'>Bilabankinn</Field_2><Field_5 FieldCaption='Address'>Skemmuvegur 4</Field_5><Field_7 FieldCaption='City'>Kopavogur</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>IS-200</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>bilabankinn@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>35451236</Field_1><Field_2 FieldCaption='Name'>Gagn &amp; Gaman</Field_2><Field_5 FieldCaption='Address'>Reykjavikurvegi 66</Field_5><Field_7 FieldCaption='City'>Hafnafjordur</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>IS-220</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>gagn.gaman@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>35963852</Field_1><Field_2 FieldCaption='Name'>Heimilisprydi</Field_2><Field_5 FieldCaption='Address'>Hallarmula</Field_5><Field_7 FieldCaption='City'>Reykjavik</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>IS-108</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>heimilisprydi@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>38128456</Field_1><Field_2 FieldCaption='Name'>MEMA Ljubljana d.o.o.</Field_2><Field_5 FieldCaption='Address'>Slovenska ccsta 127</Field_5><Field_7 FieldCaption='City'>Ljubljana</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>SI-1000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>mema.ljubljana.doo@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>38546552</Field_1><Field_2 FieldCaption='Name'>EXPORTLES d.o.o.</Field_2><Field_5 FieldCaption='Address'>Zvornarska ulica 5</Field_5><Field_7 FieldCaption='City'>Ljubljana</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>SI-1000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>exportles.doo@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>38632147</Field_1><Field_2 FieldCaption='Name'>Centromerkur d.o.o.</Field_2><Field_5 FieldCaption='Address'>Tabor 23</Field_5><Field_7 FieldCaption='City'>Maribor</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>SI-2000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>centromerkur.doo@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>40000</Field_1><Field_2 FieldCaption='Name'>Deerfield Graphics Company</Field_2><Field_5 FieldCaption='Address'>10 Deerfield Road</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>31772</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>deerfield.graphics.company@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>41231215</Field_1><Field_2 FieldCaption='Name'>Sonnmatt Design</Field_2><Field_5 FieldCaption='Address'>Sonnmattstrasse 5</Field_5><Field_7 FieldCaption='City'>Glattbrugg</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>CH-8152</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>sonnmatt.design@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>41497647</Field_1><Field_2 FieldCaption='Name'>Pilatus AG</Field_2><Field_5 FieldCaption='Address'>Bergstrasse 12</Field_5><Field_7 FieldCaption='City'>Luzern</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>CH-6005</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>pilatus.ag@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>41597832</Field_1><Field_2 FieldCaption='Name'>Möbel Scherrer AG</Field_2><Field_5 FieldCaption='Address'>Rheinstrasse 2</Field_5><Field_7 FieldCaption='City'>Schaffhausen</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>CH-8200</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>mobel.scherrer.ag@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>42147258</Field_1><Field_2 FieldCaption='Name'>BYT-KOMPLET s.r.o.</Field_2><Field_5 FieldCaption='Address'>V.Nezvala 5</Field_5><Field_7 FieldCaption='City'>Bojkovice</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>CZ-687 01</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>byt-komplet.sro@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>42258258</Field_1><Field_2 FieldCaption='Name'>J &amp; V v.o.s.</Field_2><Field_5 FieldCaption='Address'>Fillova 128</Field_5><Field_7 FieldCaption='City'>Vracov</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>CZ-696 42</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>j.v.vos@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>42369147</Field_1><Field_2 FieldCaption='Name'>PLECHKONSTRUKT a.s.</Field_2><Field_5 FieldCaption='Address'>Loosova 14</Field_5><Field_7 FieldCaption='City'>Znojmo</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>CZ-669 02</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>plechkonstrukt.as@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>43687129</Field_1><Field_2 FieldCaption='Name'>Designstudio Gmunden</Field_2><Field_5 FieldCaption='Address'>Seepromenade 1b</Field_5><Field_7 FieldCaption='City'>Gmunden</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>AT-4810</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>designstudio.gmunden@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>43852147</Field_1><Field_2 FieldCaption='Name'>Michael Feit - Möbelhaus</Field_2><Field_5 FieldCaption='Address'>Straße 33, Obj. 11</Field_5><Field_7 FieldCaption='City'>Wr. Neudorf</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>AT-2355</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>michael.feit.mobelhaus@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>43871144</Field_1><Field_2 FieldCaption='Name'>Möbel Siegfried</Field_2><Field_5 FieldCaption='Address'>Raxstraße 47</Field_5><Field_7 FieldCaption='City'>Wien</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>AT-1100</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>mobel.siegfried@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>44171511</Field_1><Field_2 FieldCaption='Name'>Zuni Home Crafts Ltd.</Field_2><Field_5 FieldCaption='Address'>456 Main Street</Field_5><Field_7 FieldCaption='City'>Dudley</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>GB-DY5 4DJ</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>zuni.home.crafts.ltd@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>44180220</Field_1><Field_2 FieldCaption='Name'>Afrifield Corporation</Field_2><Field_5 FieldCaption='Address'>100 Maidstone Ave.</Field_5><Field_7 FieldCaption='City'>Maidstone</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>GB-ME5 6RL</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>afrifield.corporation@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>44756404</Field_1><Field_2 FieldCaption='Name'>London Light Company</Field_2><Field_5 FieldCaption='Address'>235 Peachtree Street</Field_5><Field_7 FieldCaption='City'>Cambridge</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>GB-PE17 4RN</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>london.light.company@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>45282828</Field_1><Field_2 FieldCaption='Name'>Candoxy Kontor A/S</Field_2><Field_5 FieldCaption='Address'>Carl Blochs Gade 7</Field_5><Field_7 FieldCaption='City'>AArhus C</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DK-8000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>candoxy.kontor.as@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>45282829</Field_1><Field_2 FieldCaption='Name'>Carl Anthony</Field_2><Field_5 FieldCaption='Address'>De Mezas Plads 917B</Field_5><Field_7 FieldCaption='City'>AArhus C</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DK-8000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>carl.anthony@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>45779977</Field_1><Field_2 FieldCaption='Name'>Ravel M¢bler</Field_2><Field_5 FieldCaption='Address'>Parkvej 44</Field_5><Field_7 FieldCaption='City'>Nyborg</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DK-5800</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>ravel.mobler@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>45979797</Field_1><Field_2 FieldCaption='Name'>Lauritzen Kontorm¢bler A/S</Field_2><Field_5 FieldCaption='Address'>Jomfru Ane Gade 56</Field_5><Field_7 FieldCaption='City'>Ålborg</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DK-9000</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>lauritzen.kontormobler.as@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>46251425</Field_1><Field_2 FieldCaption='Name'>Marsholm Karmstol</Field_2><Field_5 FieldCaption='Address'>Tylö Fackhandel</Field_5><Field_7 FieldCaption='City'>Halmstad</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>SE-302 50</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>marsholm.karmstol@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>46525241</Field_1><Field_2 FieldCaption='Name'>Konberg Tapet AB</Field_2><Field_5 FieldCaption='Address'>Linnégatan 15</Field_5><Field_7 FieldCaption='City'>Jönköbing</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>SE-550 05</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>konberg.tapet.ab@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>46897889</Field_1><Field_2 FieldCaption='Name'>Englunds Kontorsmöbler AB</Field_2><Field_5 FieldCaption='Address'>Kungsgatan 18</Field_5><Field_7 FieldCaption='City'>Norrköbing</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>SE-600 03</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>englunds.kontorsmobler.ab@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>47523687</Field_1><Field_2 FieldCaption='Name'>Slubrevik Senger AS</Field_2><Field_5 FieldCaption='Address'>Storgt. 5</Field_5><Field_7 FieldCaption='City'>Asker</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>NO-1370</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>slubrevik.senger.as@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>47563218</Field_1><Field_2 FieldCaption='Name'>Klubben</Field_2><Field_5 FieldCaption='Address'>Skogveien 3</Field_5><Field_7 FieldCaption='City'>Haslum</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>NO-1344</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>klubben@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>47586954</Field_1><Field_2 FieldCaption='Name'>Sj¢boden</Field_2><Field_5 FieldCaption='Address'>Ytre Sandgt. 13</Field_5><Field_7 FieldCaption='City'>Sandvika</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>NO-1300</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>sjoboden@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>49525252</Field_1><Field_2 FieldCaption='Name'>Beef House</Field_2><Field_5 FieldCaption='Address'>Südermarkt 6</Field_5><Field_7 FieldCaption='City'>Düsseldorf</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DE-40593</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>beef.house@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>49633663</Field_1><Field_2 FieldCaption='Name'>Autohaus Mielberg KG</Field_2><Field_5 FieldCaption='Address'>Porschestraße 911</Field_5><Field_7 FieldCaption='City'>Hamburg 36</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DE-22417</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>autohaus.mielberg.kg@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>49858585</Field_1><Field_2 FieldCaption='Name'>Hotel Pferdesee</Field_2><Field_5 FieldCaption='Address'>Plett Straße 187</Field_5><Field_7 FieldCaption='City'>Frankfurt/Main</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DE-60320</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>hotel.pferdesee@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>50000</Field_1><Field_2 FieldCaption='Name'>Guildford Water Department</Field_2><Field_5 FieldCaption='Address'>25 Water Way</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>31772</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>guildford.water.department@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>60000</Field_1><Field_2 FieldCaption='Name'>Blanemark Hifi Shop</Field_2><Field_5 FieldCaption='Address'>28 Baker Street</Field_5><Field_7 FieldCaption='City'>London</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>GB-W1 3AL</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'/></Customer><Customer><Field_1 FieldCaption='No.'>61000</Field_1><Field_2 FieldCaption='Name'>Fairway Sound</Field_2><Field_5 FieldCaption='Address'>159 Fairway</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>31772</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'/></Customer><Customer><Field_1 FieldCaption='No.'>62000</Field_1><Field_2 FieldCaption='Name'>The Device Shop</Field_2><Field_5 FieldCaption='Address'>273 Basin Street</Field_5><Field_7 FieldCaption='City'>London</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>GB-N16 34Z</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'/></Customer><Customer><Field_1 FieldCaption='No.'>IC1020</Field_1><Field_2 FieldCaption='Name'>Cronus Cardoxy Sales</Field_2><Field_5 FieldCaption='Address'>Ligeudvej 24</Field_5><Field_7 FieldCaption='City'>K¢benhavn ¥</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DK-2100</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>cronus.cardoxy.sales@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>IC1030</Field_1><Field_2 FieldCaption='Name'>Cronus Cardoxy Procurement</Field_2><Field_5 FieldCaption='Address'>Geradeausweg 77</Field_5><Field_7 FieldCaption='City'>Hamburg</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DE-20097</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>cronus.cardoxy.procurement@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE30000</Field_1><Field_2 FieldCaption='Name'>Danish Treats</Field_2><Field_5 FieldCaption='Address'>54 Ostergale</Field_5><Field_7 FieldCaption='City'>Copenhagen</Field_7><Field_92 FieldCaption='State'/><Field_91 FieldCaption='ZIP Code'>DK-2400</Field_91><Field_9 FieldCaption='Phone No.'>45 45 32 1238</Field_9><Field_102 FieldCaption='E-Mail'>Bill.Watson@DanishTreats.dk</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE35000</Field_1><Field_2 FieldCaption='Name'>Canadian Treats</Field_2><Field_5 FieldCaption='Address'>1450 Baker Street</Field_5><Field_7 FieldCaption='City'>Edmonton</Field_7><Field_92 FieldCaption='State'>AB</Field_92><Field_91 FieldCaption='ZIP Code'>CA-T5J4L6</Field_91><Field_9 FieldCaption='Phone No.'>210-333-4343</Field_9><Field_102 FieldCaption='E-Mail'>Bill.Watson@CanadianTreats.ca</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE50000</Field_1><Field_2 FieldCaption='Name'>ABC Automotive, Inc.</Field_2><Field_5 FieldCaption='Address'>192 Market Square</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE55000</Field_1><Field_2 FieldCaption='Name'>XYZ Automotive Group</Field_2><Field_5 FieldCaption='Address'>192 Market Square</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE60000</Field_1><Field_2 FieldCaption='Name'>ABC Retail Group, Inc.</Field_2><Field_5 FieldCaption='Address'>192 Market Square</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE61000</Field_1><Field_2 FieldCaption='Name'>XYZ Retail Group, Inc.</Field_2><Field_5 FieldCaption='Address'>192 Market Square</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE65000</Field_1><Field_2 FieldCaption='Name'>XYZ Group</Field_2><Field_5 FieldCaption='Address'>192 Market Square</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE70000</Field_1><Field_2 FieldCaption='Name'>Mann Supply Co.</Field_2><Field_5 FieldCaption='Address'>98123 Confederate Ave.</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE70001</Field_1><Field_2 FieldCaption='Name'>Maid Supply Co.</Field_2><Field_5 FieldCaption='Address'>98124 Confederate Ave.</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE70020</Field_1><Field_2 FieldCaption='Name'>Blanemark Hifi Enterprises</Field_2><Field_5 FieldCaption='Address'>3432 Second St.</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE80000</Field_1><Field_2 FieldCaption='Name'>IDS Products</Field_2><Field_5 FieldCaption='Address'>301 Pike St.</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer><Customer><Field_1 FieldCaption='No.'>SE90000</Field_1><Field_2 FieldCaption='Name'>Pickens Design Group</Field_2><Field_5 FieldCaption='Address'>9987 Pharr Rd.</Field_5><Field_7 FieldCaption='City'>Atlanta</Field_7><Field_92 FieldCaption='State'>GA</Field_92><Field_91 FieldCaption='ZIP Code'>30093</Field_91><Field_9 FieldCaption='Phone No.'/><Field_102 FieldCaption='E-Mail'>the.cannon.group.plc@cronuscorp.net</Field_102></Customer></Customers></GetCustomerList>";
	}
}