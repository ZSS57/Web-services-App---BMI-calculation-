//
//  MoreInfoViewController.swift
//  BMI-part2
//
//  Created by zhaos on 6/24/22.
//  Copyright © 2022 zhaos. All rights reserved.
//

import UIKit
import WebKit

class MoreInfoViewController: UIViewController {
    
    @IBOutlet weak var webview: WKWebView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        self.title = "Web View"
        //url
        //let myURL = URL(string: "https://www.nhlbi.nih.gov/health/educational/lose_wt/index.htm")
        let myURL = URL(string: "https://www.cdc.gov/healthyweight/assessing/bmi/index.html")
        //request
        let myRequest = URLRequest(url:myURL!)
        //load
        webview.load(myRequest)
        
        
        // Do any additional setup after loading the view.
    }
    

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
    }
    */

}
