using System;
using System.Web.Http.Controllers;

namespace Ryan.Utility.ModelBinders
{
    /// <summary>
    /// </summary>
    public class MvcStyleBindingAttribute : Attribute, IControllerConfiguration
    {
        /// <summary>
        ///     Callback invoked to set per-controller overrides for this controllerDescriptor.
        /// </summary>
        /// <param name="controllerSettings">The controller settings to initialize.</param>
        /// <param name="controllerDescriptor">
        ///     The controller descriptor. Note that the
        ///     <see cref="T:System.Web.Http.Controllers.HttpControllerDescriptor" /> can be associated with the derived controller
        ///     type given that <see cref="T:System.Web.Http.Controllers.IControllerConfiguration" /> is inherited.
        /// </param>
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            controllerSettings.Services.Replace(typeof (IActionValueBinder), new MvcActionValueBinder());
        }
    }
}