using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Logger : MonoBehaviour
{
	public string position_file_pre; // file will be named 'position_file_pre_<name>_<age>_<gender>_<group>.csv'
	public string heading_file_pre; // file will be named 'heading_file_pre_<name>_<age>_<gender>_<group>.csv'

    public float log_every = 0.2f; // how long to wait between logging

    public GameObject participant;
	public State state;

	private Writer position_writer;
	private Writer heading_writer;

	class Writer
    {
		private StreamWriter stream_writer;

		public void Write(string line)
        {
			this.stream_writer.WriteLine(line);
        }

		public void Close()
        {
			this.stream_writer.Close();
        }

		public Writer(string log_file)
        {
			this.stream_writer = new StreamWriter(Application.persistentDataPath + "_" + log_file);
        }
    }

	string ComposeFileName(string file_pre)
    {
        return file_pre + "_" + state.first_name + "_" + state.age + "_" + state.gender + "_" + state.group + ".csv";
    }

    // start is called before the first frame update
    public void StartLogging()
    {
		Debug.Log("Starting logging to: "+Application.persistentDataPath);
		position_writer = new Writer(ComposeFileName(position_file_pre));
		heading_writer = new Writer(ComposeFileName(heading_file_pre));

		LogPlayerHeadingHeader();
		LogPlayerPositionHeader();

		InvokeRepeating("LogPlayerPosition", 0f, log_every);
		InvokeRepeating("LogPlayerHeading", 0f, log_every);
    }

	string Vector3ToCSV(Vector3 vector)
    {
		return vector.x.ToString() + "," + vector.y.ToString() + "," + vector.z.ToString();
    }

	void LogPlayerHeadingHeader()
    {
		heading_writer.Write("time,progress,x,y,z");
    }

	void LogPlayerPositionHeader()
    {
		position_writer.Write("time,progress,x,y,z");
    }

	void LogPlayerHeading()
    {
		string line = state.TimeSinceStart().ToString() + "," + state.GetProgress().ToString() + ",";
		line += Vector3ToCSV(participant.transform.Find("MainCamera").transform.forward);
		heading_writer.Write(line);
    }


	void LogPlayerPosition()
    {
		string line = state.TimeSinceStart().ToString() + "," + state.GetProgress().ToString() + ",";
		line += Vector3ToCSV(participant.transform.position);
		position_writer.Write(line);

    }

    // update is called once per frame
    void Update()
    {
        
    }
	
	public void OnDestroy(){
		position_writer.Close();
		heading_writer.Close();
		
	}

}
