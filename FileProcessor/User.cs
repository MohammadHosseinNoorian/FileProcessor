using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace FileProcessor;

public class User
{
    private static int _lastId = 999999;//start IDs at 1,000,000
    public int Id { get; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public User(string name, string addr)
    {
        FullName = name;
        Address = addr;
        Id = ++_lastId;
    }
    public override string ToString()
    {
        return $"Mr/Ms {FullName} lives in {Address} with id : {Id}";
    }
}
