﻿using System;
using System.Globalization;

public class GetResponse
{
	public int count { get; set; }
	public List<NamedApiResource> results { get; set; }
	public string name { get; set; }
	public int height { get; set; }
	public int weight { get; set; }
	public int base_experience { get; set; }
	public string location_area_encounters { get; set; }
}
