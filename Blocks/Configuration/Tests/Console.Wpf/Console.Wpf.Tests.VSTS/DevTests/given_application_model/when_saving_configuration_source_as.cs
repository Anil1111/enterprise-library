﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Console.Wpf.Tests.VSTS.DevTests.given_shell_service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Moq;
using Microsoft.Win32;
using Console.Wpf.ViewModel.Services;
using System.Windows;


namespace Console.Wpf.Tests.VSTS.DevTests.given_application_model
{

    [DeploymentItem("save_as_target.config")]
    public abstract class save_as_context : given_dirty_application_model
    {
        protected static string SaveAsTargetFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save_as_target.config");

        protected override void Arrange()
        {
            base.Arrange();
            base.UIServiceMock.Setup(x => x.ShowFileDialog(It.IsAny<SaveFileDialog>())).Returns(new FileDialogResult { DialogResult = true, FileName = SaveAsTargetFile });
        }
    }

    [TestClass]
    public class when_saving_configuration_source_as : save_as_context
    {
        protected override void Arrange()
        {
            base.Arrange();

            File.Delete(SaveAsTargetFile);
        }

        protected override void Act()
        {
            ApplicationModel.SaveAs();
        }

        [TestMethod]
        public void then_file_is_created()
        {
            Assert.IsTrue(File.Exists(SaveAsTargetFile));
        }
    }

    [TestClass]
    public class when_saving_configuration_source_as_and_overwriting_file : save_as_context
    {
        private DateTime lastWriteTimeSaveAsTarget;

        protected override void Arrange()
        {
            base.Arrange();

            lastWriteTimeSaveAsTarget = File.GetLastWriteTime(SaveAsTargetFile);
            File.WriteAllText(SaveAsTargetFile, "<configuration />");
        }

        protected override void Act()
        {
            ApplicationModel.SaveAs();
        }

        [TestMethod]
        public void then_file_is_written_to()
        {
            Assert.AreNotEqual(lastWriteTimeSaveAsTarget, File.GetLastWriteTime(SaveAsTargetFile));
        }
    }

    [TestClass]
    public class when_saving_configuration_source_as_and_overwriting_non_configuration_file : save_as_context
    {
        private DateTime lastWriteTimeSaveAsTarget;

        protected override void Arrange()
        {
            base.Arrange();

            File.WriteAllText(SaveAsTargetFile, "this is a text file now");
            lastWriteTimeSaveAsTarget = File.GetLastWriteTime(SaveAsTargetFile);

            UIServiceMock.Setup(x => x.ShowMessageWpf(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButton.OKCancel))
                         .Returns(MessageBoxResult.OK)
                         .Verifiable();
        }

        protected override void Act()
        {
            ApplicationModel.SaveAs();
        }

        [TestMethod]
        public void then_warning_message_was_shown()
        {
            UIServiceMock.Verify();
        }

        [TestMethod]
        public void then_file_is_written_to()
        {
            Assert.AreNotEqual(lastWriteTimeSaveAsTarget, File.GetLastWriteTime(SaveAsTargetFile));
        }
    }

    [TestClass]
    public class when_saving_configuration_source_as_and_backing_out_ofoverwriting_non_configuration_file : save_as_context
    {
        private DateTime lastWriteTimeSaveAsTarget;

        protected override void Arrange()
        {
            base.Arrange();

            File.WriteAllText(SaveAsTargetFile, "this is a text file now");
            lastWriteTimeSaveAsTarget = File.GetLastWriteTime(SaveAsTargetFile);

            UIServiceMock.Setup(x => x.ShowMessageWpf(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButton.OKCancel))
                         .Returns(MessageBoxResult.Cancel)
                         .Verifiable();
        }

        protected override void Act()
        {
            ApplicationModel.SaveAs();
        }

        [TestMethod]
        public void then_warning_message_was_shown()
        {
            UIServiceMock.Verify();
        }

        [TestMethod]
        public void then_file_is_not_written_to()
        {
            Assert.AreEqual(lastWriteTimeSaveAsTarget, File.GetLastWriteTime(SaveAsTargetFile));
        }
    }

}