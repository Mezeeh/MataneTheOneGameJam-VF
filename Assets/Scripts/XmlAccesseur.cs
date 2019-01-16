using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class XmlAccesseur{

	 private string scoreXml;
     public static XmlAccesseur instance = null;
    public XmlAccesseur()
    {
        scoreXml = @"../../Scores.xml";
       
    }
    public static XmlAccesseur getInstance()
    {
        if(instance == null)
            instance = new XmlAccesseur();
        return instance;
    }

    public void save(List<ScoreSaveObject> scores)
    {

        try
        {
            if(File.Exists(scoreXml))
            {
                List<ScoreSaveObject> savedScores = load();
                foreach(ScoreSaveObject score in scores)
                {
                    savedScores.Add(score);
                }
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<ScoreSaveObject>));
                FileStream fs = File.Create(scoreXml);
                xSeriz.Serialize(fs, savedScores);
                fs.Close();
            }
            else
            {
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<ScoreSaveObject>));
                FileStream fs = File.Create(scoreXml);
                xSeriz.Serialize(fs, scores);
                fs.Close();
            }
           
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    public List<ScoreSaveObject> load()
    {
        try
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<ScoreSaveObject>));
            StreamReader file = new StreamReader(scoreXml);
            List<ScoreSaveObject> scores = (List<ScoreSaveObject>)reader.Deserialize(file);
            file.Close();
            return scores;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }
}
