using System;

public class Team : INameAndCopy
{
    protected string nameOrganiz;
	protected int registrId;
	public string NameOrganiz
	{
		set 
		{
			if (value == "")
			{
                throw new Exception("Пустая строка",value);
            }
			else
			{
                nameOrganiz = value;
            }
		}
		get { return nameOrgani; }
	}
	public int RegistrId
	{
		set 
		{
			if(value < 0)
			{
				throw new ArgumentException("Реистрационный номер не может быть 0 или меньше",value);
			}
			else
			{
                registrId = value;
            }
		}
		get { return registrId; }
	}
    public Team()
	{
		registrId = 0;
		NameOrganiz = "default";
    }
	public Team (string nameOrganiz , int regisrtId)
	{
		this.nameOrganiz = nameOrganiz;
		this.registrId = regisrtId;
	}


}
