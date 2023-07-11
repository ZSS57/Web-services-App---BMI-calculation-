//
//  ViewController.swift
//  BMI-part2
//
//  Created by zhaos on 6/24/22.
//  Copyright © 2022 zhaos. All rights reserved.
//

import UIKit


class ViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        Educateme.layer.cornerRadius = 15
        BMIAPI.layer.cornerRadius = 15
        height.text = ""
        weight.text = ""
        
        // Do any additional setup after loading the view.
      
    }
    var textColor: UIColor?

    @IBOutlet weak var height: UITextField!
    @IBOutlet weak var weight: UITextField!
    
    @IBOutlet weak var BMIResult: UILabel!
    @IBOutlet weak var RiskResult: UILabel!
    
    @IBOutlet weak var Educateme: UIButton!
    @IBOutlet weak var BMIAPI: UIButton!
    
    
    struct myHealth: Decodable {
        
        var bmi:Double
        var risk:String
        var more:[String]

    }
  
    @IBAction func Calculate(_ sender: UIButton) {
       
        self.view.endEditing(true)
        
        let data1 = (height.text! as NSString).doubleValue
        let data2 = (weight.text! as NSString).doubleValue
        
        
        let urlAsString =
           "http://webstrar99.fulton.asu.edu/page3/Service1.svc/calculateBMI?height=\(data1)&weight=\(data2)"
        /*
        let path = "http://webstrar99.fulton.asu.edu/page3/Service1.svc/calculateBMI?height=60&weight=156"
        let urlstring = path.addingPercentEncoding(withAllowedCharacters: .urlQueryAllowed)
        //request
        let myURL = URL(string: urlstring!)!
    */
        
        let url = URL(string:urlAsString)!
        let urlSession = URLSession.shared
        
        
        let jsonQuery = urlSession.dataTask(with: url,completionHandler: {data,response,error-> Void in
         
            guard let data = data, error == nil else{
                print("Something went wrong")
              
                return
            }
            
            let decoder = JSONDecoder()
            let jsonResult = try! decoder.decode(myHealth.self,from: data)
         
            
            let bmi = jsonResult.bmi
            let risk = jsonResult.risk
            //let more = jsonResult.more
        
            let res = "\(bmi)"
            
            
            
            DispatchQueue.main.async {
            self.BMIResult.text = res
            self.RiskResult.text = risk
            
            
            if self.RiskResult.text == "You are underweight :("{
                self.RiskResult.textColor = UIColor.blue}
            
            if self.RiskResult.text == "You are normal :)"{
                self.RiskResult.textColor = UIColor.green}
                               
            if self.RiskResult.text == "You are pre-obese!"{
                self.RiskResult.textColor = UIColor.purple}
            
            if self.RiskResult.text == "You are obese :("{
                self.RiskResult.textColor = UIColor.red}
                
        }
            
            
        })
        
        
        jsonQuery.resume()
    
    }
    /*
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if segue.identifier == "MoreInfoViewController" {
            
            if let MoreInfoViewController: ViewController = segue.destination as? ViewController{
                MoreInfoViewController.url = "https://www.nhlbi.nih.gov/health/educational/lose_wt/index.htm"
            
        }
        
        }

    }
*/
}


