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
        scoreXml = @"../Scores.xml";
       
    }
    public static XmlAccesseur getInstance()
    {
        if(instance == null)
            instance = new XmlAccesseur();
        return instance;
    }

    public void save(ScoreSaveObject newScore)
    {

        try
        {
            if(File.Exists(scoreXml))
            {
                List<ScoreSaveObject> savedScores = load();
                ScoreSaveObject oldScore = savedScores.Find(x => x.nom == newScore.nom);
                if(oldScore != null)
                {
                   //Update score
                    if(newScore.score > oldScore.score)
                    {
                        oldScore.score = newScore.score;
                    }
                }
                else
                    savedScores.Add(newScore);
              

                savedScores.Sort(sortByScores);

                XmlSerializer xSeriz = new XmlSerializer(typeof(List<ScoreSaveObject>));
                FileStream fs = File.Create(scoreXml);
                xSeriz.Serialize(fs, savedScores);
                fs.Close();
            }
            else
            {
                List<ScoreSaveObject> scores = new List<ScoreSaveObject>();
                scores.Add(newScore);
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

    private int sortByScores(ScoreSaveObject score1, ScoreSaveObject score2)
    {
        return score1.score.CompareTo(score2.score) * -1;
    }
}
