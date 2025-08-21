public class ScryfallListResponse<T>
{
	public string Object { get; set; }
	public int Total_Cards { get; set; }
	public bool Has_More { get; set; }
	public string Next_Page { get; set; }
	public List<T> Data { get; set; }
}
