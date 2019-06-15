public struct SRecord
{
    public string m_name;
    public int m_score;

    public string Name { get; set; }
    public int Score { get; set; }

    public SRecord(string name, int score)
    {
        m_name = name;
        m_score = score;

        Name = m_name;
        Score = m_score;
    }
}
