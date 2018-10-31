using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModels;
using DataRepository;
using System.IO;

namespace BusinessLogic
{
    public class LetterGeneration
    {
        private RepositoryMethods repo;
        private InvitationLetterFeilds feilds;
        
        
       public LetterGeneration()
        {
            repo = new RepositoryMethods();
        }
        public void generateLetterOnDesig(int travelId, TravelRequest approvedTravel)
        {
            
            if(approvedTravel.StatusId == 2)
            {
                
                string templatePath = repo.getInvitationFormat(travelId, approvedTravel);
                if(templatePath != null)
                {
                    string text = File.ReadAllText(templatePath, Encoding.UTF8);
                    //keeep the feilds ready for thr file
                    feilds = repo.getFeildsForInvitationLetter(approvedTravel);
                    if(feilds != null)
                    {
                        this.createFile(text,feilds);
                    }
                    else
                    {
                        throw new System.ArgumentException("the feilds to be filled in the text file is null", "feilds:null");
                    }
                    
                }
                else
                {
                    throw new System.ArgumentException(" NO InvitationTemplaten found for this designation check InvitationLetterFormatsTable In DB", "");
                }
                
              
                

            }
        }

        public void createFile(string content,InvitationLetterFeilds feilds)
        {
            string fileName =  feilds.travelName + feilds.empId.ToString() + feilds.travelId.ToString(); 
            string dirPath = @"C:\kdtp\emp_invit_letters\";
            string filePath = $"{dirPath}" + fileName;

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            
            if (!File.Exists(filePath))
            {
                using (TextWriter tw = new StreamWriter(filePath))
                {
                    
                        content =content.Replace("@name@", feilds.EmployeeName);
                        content = content.Replace("@place@", feilds.Place);
                    content = content.Replace("@project@", feilds.ProjectName);
                    content = content.Replace("@client@", feilds.ClientName);
                    content = content.Replace("@startdate@", feilds.StartDate.ToString());
                    content = content.Replace("@enddate@", feilds.EndDate.ToString());
                    content = content.Replace("@manager@", feilds.managerName);
                    

                    tw.WriteLine(content);

                    this.insertFilePath(filePath,feilds.travelId);
                     tw.Close();
                }

            }
            else
            {
                throw new System.ArgumentException("file already exists", "fileName");

            }
            
        }

        public void insertFilePath(string filePath,int travelId)
        {
            repo.insertFilePath(filePath, travelId);
        }
        
    }
}
