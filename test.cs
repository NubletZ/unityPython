using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Python.Included;
using Python.Runtime;
using System.IO;

public class test : MonoBehaviour
{
    PyObject cv2, cvzone, handTrack, importlib;
    public GameObject Hand;
    public Sprite Hand0;
    public Sprite Hand5;
    // Start is called before the first frame update
    async void Start()
    {
        Installer.InstallPath = Path.GetFullPath("."); //to declare workdir
        Debug.Log($"Working directory : {Path.GetFullPath(".")}");
        await Installer.SetupPython();

        PythonEngine.Initialize();
        if (Installer.IsPipInstalled()) Debug.Log("Pip has been installed :)");

        Debug.Log("== importing modules ==");
        dynamic sys = Py.Import("sys");
        Debug.Log("sys has been imported..");
        string curPath = "F:/myUNITY/TryPython/Assets"; //path of the app
        sys.path.insert(1, @$"{curPath}\python-3.7.3-embed-amd64\Lib\site-packages\cvzone");
        importlib = Py.Import("importlib");
        Debug.Log("importlib has been imported..");

        cvzone = Py.Import("cvzone");
        Debug.Log("cvzone has been imported..");
        Debug.Log($"import first {cvzone}");

        //dynamic selfseg = Py.Import("SelfiSegmentationModule");
        //Debug.WriteLine("SelfiSegmentationModule has been imported..");
        //handTrack = Py.Import("HandTrackingModule");
        //Debug.Log("HandTrackingModule has been imported.."); 
        //cv2 = Py.Import("cv2");
        //Debug.Log("cv2 has been imported..");
        dynamic os = Py.Import("os");
        Debug.Log("os has been imported..");
        //dynamic im = Py.Import("PIL.Image");
        //Debug.WriteLine("PIL.Image has been imported..");
        //var segmentor = selfseg.SelfiSegmentation(1);
        Debug.Log("== finished importing ==");
        Debug.Log($"Python version: {sys.version}");

        //cap = cv2.VideoCapture(0);
        //detector = handTrack.HandDetector(0.5, 3);


        /*var bitmap1 = new BitmapImage();
        bitmap1.BeginInit();
        bitmap1.CacheOption = BitmapCacheOption.OnLoad;*/

        //OpenCvSharp version
        //Mat src = new Mat();
        //FrameSource frame = Cv2.CreateFrameSource_Camera(0);

        //find specific object
        //Hand = GameObject.Find("Hand");
    }

    dynamic cap;
    dynamic detector;
    bool flag = true;
    // Update is called once per frame
    void Update()
    {
        /*
        if (flag)
        {
            cap.set(3, 640);
            cap.set(4, 480);
            var fpsReader = cvzone.FPS();
            var imgs = cap.read();
            var img = imgs[1];
            img = cv2.flip(img, 1);
            var hands = detector.findHands(img);
            //var length = hands.Length().ToString();
            if (hands[0])
            {
                var hand = hands[0][0];
                //Debug.Log($"hands={hands[0][0]}");
                string type = hand["type"].ToString();
                //var handPoint = hand["center"];
                var handPoint = hand["lmList"][0];
                var handX = handPoint[0];
                var handY = handPoint[1];
                float x = ((float)handX - 320f) / 100f;
                float y = -((float)handY - 240f) / 100f;
                //Debug.Log($"x = {x}, y = {y}");
                //Debug.Log($"Hand Point = {hands[0][0]}");
                Hand.transform.position = new Vector3(x, y, -1f);
                var finger = detector.fingersUp(hands[0][0]);
                int sumFinger = finger[0] + finger[1] + finger[2] + finger[3] + finger[4];
                try
                {
                    
                    if (sumFinger == 0)
                    {
                        Hand.gameObject.GetComponent<SpriteRenderer>().sprite = Hand0;
                        Debug.Log("Hand0");
                    }
                    else
                    {
                        Hand.gameObject.GetComponent<SpriteRenderer>().sprite = Hand5;
                        Debug.Log("Hand5");
                    }
                    
                } catch
                {
                    Debug.Log("failed!!");
                }
            }
            var disp = hands[1];
            disp = fpsReader.update(disp)[1];
            cv2.imshow("Image", disp);
            cv2.waitKey(1);
            //Debug.Log($"DISP = {disp}");
        */
        if (Input.GetKey("escape") && flag)
            {
            //cap.release();
            //flag = false;
            //cv2.destroyAllWindows();

            cvzone.Dispose();
            Debug.Log($"last {cvzone}");
            Debug.Log("cvzone has been disposed");
            flag = false;
                //Application.Quit();
                //PythonEngine.Shutdown();
            }
            
        //}
    }
}
