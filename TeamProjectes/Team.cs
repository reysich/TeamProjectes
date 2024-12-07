using System;

public class Team
{
    protected string nameOrganiz;
	protected int registrId;
	public string NameOrganiz
	{
		set { nameOrganiz = value; }
		get { return nameOrgani; }
	}
	public int RegistrId
	{
		set { registrId = value; }
		get { return registrId; }
	}
    public Team()
	{
	}
	public Team (string nameOrganiz , int regisrtId)
	{
		this.nameOrganiz = nameOrganiz;
		this.registrId = regisrtId;
	}
}
