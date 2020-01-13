using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmaraCode.CManager.AppService;
using AmaraCode.CManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmaraCode.CManager.Controllers
{
    /// <summary>
    /// This controller uses the ConversationAppService to keep the controller thin.  The AppService
    /// is injected using DI into the constructor.  
    /// </summary>

    
    public class ConversationController : Controller
    {
        //for direct access to the AppService
        private ConversationAppService _service;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cas"></param>
        public ConversationController(ConversationAppService cas)
        {
            _service = cas;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new ConversationCreateViewModel();
            return View(model);
        }



        [HttpGet]
        public IActionResult CreateForCompany(ConversationCreateViewModel model)
        {
            ConversationCreateViewModel result =  _service.Create(model.CompanyID);
            return View("create", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ConversationCreateViewModel model)
        {
            var result = _service.Create(model);
            return Redirect(model.ReturnUrl);
        }


        [HttpGet]
        public IActionResult CreateFromExisting(ConversationCreateViewModel model)
        {
            //take the conversationID and find the existing converstation,
            //copy all the person information and start a new conversation

            //ConversationCreateViewModel result = _service.CreateFromExisting(model.ID);
            //result.ReturnURL = model.ReturnUrl;

            return View("Create", model);

        }


        [HttpPost]
        public IActionResult Delete(Guid id, string returnUrl)
        {
            _service.Delete(id);
            TempData["message"] = "Conversation Deleted";
            return Redirect(returnUrl);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult List()
        {
            ConversationsViewModel result = _service.GetConversations(null);
            return View(result);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Company(Guid id)
        {
            ConversationsViewModel result = _service.GetConversations(id);
            return View("List", result);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit( ConversationEditViewModel model)
        {

            //call the GetConversation method to get the conversation along with the 
            //company information.  The AppService returns a ConversationCompanyViewModel 
            //class which we will utilize to populate the ConversationEditViewModel class
            //that we actually need.
            ConversationCompanyViewModel result = _service.GetConversation(model.ID);



            //note that this will error if the company comes back null.  Just a caution
            //if you plan to edit the json files manually.  We might trap for it later.
            var cevm = new ConversationEditViewModel
            {
                CallBack = result.Conversation.CallBack,
                CompanyID = result.Conversation.CompanyID,
                CompanyName = result.Company.CompanyName,
                Created = result.Conversation.Created,
                Discussion = result.Conversation.Discussion,
                Email = result.Conversation.Email,
                ID = result.Conversation.ID,
                Name = result.Conversation.Name,
                Phone = result.Conversation.Phone,
                ReturnURL = model.ReturnURL
            };

            return View(cevm);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPost(ConversationEditViewModel model)
        {
            
            var result = _service.EditConversation(model);
            
            TempData["message"] = "Conversation Edited";
            
            return Redirect(model.ReturnURL);
        }
    }
}